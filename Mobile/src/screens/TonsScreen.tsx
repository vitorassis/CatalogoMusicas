import React, { useState, useEffect, useCallback } from 'react';
import { StyleSheet, View, FlatList, Alert } from 'react-native';
import { FAB, List, Portal, Dialog, Button, TextInput, IconButton, Text } from 'react-native-paper';
import { useFocusEffect } from '@react-navigation/native';
import { getTonsByMusica, addTom, updateTom, deleteTom } from '../database';

export default function TonsScreen({ route, navigation }) {
  const { musicaId, musicaNome } = route.params; // Recebe os parâmetros da música
  const [tons, setTons] = useState([]);
  const [dialogVisible, setDialogVisible] = useState(false);
  const [newTonalidade, setNewTonalidade] = useState('');
  const [editingTom, setEditingTom] = useState(null); // Tom que está sendo editado

  const loadTons = async () => {
    try {
      const fetchedTons = await getTonsByMusica(musicaId);
      setTons(fetchedTons);
    } catch (error) {
      console.error("Erro ao carregar tons:", error);
      Alert.alert("Erro", "Não foi possível carregar os tons.");
    }
  };

  useFocusEffect(
    useCallback(() => {
      loadTons();
    }, [musicaId])
  );

  useEffect(() => {
    navigation.setOptions({ title: `Tons de ${musicaNome}` });
  }, [musicaNome, navigation]);

  const showDialog = (tom = null) => {
    setEditingTom(tom);
    setNewTonalidade(tom ? tom.Tonalidade : '');
    setDialogVisible(true);
  };

  const hideDialog = () => {
    setDialogVisible(false);
    setEditingTom(null);
    setNewTonalidade('');
  };

  const handleSaveTom = async () => {
    if (!newTonalidade.trim()) {
      Alert.alert("Atenção", "A tonalidade não pode ser vazia.");
      return;
    }
    try {
      if (editingTom) {
        await updateTom(editingTom.Id, newTonalidade.trim());
        Alert.alert("Sucesso", "Tonalidade atualizada!");
      } else {
        await addTom(musicaId, newTonalidade.trim());
        Alert.alert("Sucesso", "Tonalidade adicionada!");
      }
      hideDialog();
      loadTons();
    } catch (error) {
      console.error("Erro ao salvar tom:", error);
      Alert.alert("Erro", "Não foi possível salvar a tonalidade.");
    }
  };

  const handleDeleteTom = (tomId) => {
    Alert.alert(
      "Confirmar Exclusão",
      "Tem certeza que deseja excluir esta tonalidade?",
      [
        { text: "Cancelar", style: "cancel" },
        {
          text: "Excluir",
          onPress: async () => {
            try {
              await deleteTom(tomId);
              Alert.alert("Sucesso", "Tonalidade excluída!");
              loadTons();
            } catch (error) {
              console.error("Erro ao excluir tom:", error);
              Alert.alert("Erro", "Não foi possível excluir a tonalidade.");
            }
          },
          style: "destructive",
        },
      ]
    );
  };

  return (
    <View style={styles.container}>
      <FlatList
        data={tons}
        keyExtractor={(item) => item.Id.toString()}
        renderItem={({ item }) => (
          <List.Item
            title={item.Tonalidade}
            left={() => <List.Icon icon="guitar-acoustic" />}
            right={() => (
              <View style={styles.listItemActions}>
                <IconButton
                  icon="pencil"
                  onPress={() => showDialog(item)}
                  size={20}
                />
                <IconButton
                  icon="delete"
                  onPress={() => handleDeleteTom(item.Id)}
                  color="red"
                  size={20}
                />
              </View>
            )}
          />
        )}
        ListEmptyComponent={<List.Item title="Nenhum tom cadastrado para esta música. Adicione um!" />}
      />

      <FAB
        style={styles.fab}
        icon="plus"
        label="Novo Tom"
        onPress={() => showDialog()}
      />

      <Portal>
        <Dialog visible={dialogVisible} onDismiss={hideDialog}>
          <Dialog.Title>{editingTom ? 'Editar Tonalidade' : 'Nova Tonalidade'}</Dialog.Title>
          <Dialog.Content>
            <TextInput
              label="Tonalidade"
              value={newTonalidade}
              onChangeText={setNewTonalidade}
              mode="outlined"
            />
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={hideDialog}>Cancelar</Button>
            <Button onPress={handleSaveTom}>{editingTom ? 'Salvar' : 'Adicionar'}</Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  listItemActions: {
    flexDirection: 'row',
    alignItems: 'center',
    marginRight: 10,
  },
  fab: {
    position: 'absolute',
    margin: 16,
    right: 0,
    bottom: 50,
  },
});