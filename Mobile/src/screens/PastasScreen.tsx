import React, { useState, useEffect, useCallback } from 'react';
import { StyleSheet, View, FlatList, Alert } from 'react-native';
import { FAB, List, Portal, Dialog, Button, TextInput, Appbar, IconButton } from 'react-native-paper'; // Adicionado IconButton
import { useFocusEffect } from '@react-navigation/native';
import { getPastas, addPasta, deletePasta, importDatabaseFromFile } from '../database'; // Importe deletePasta

export default function PastasScreen({ navigation }) {
  const [pastas, setPastas] = useState([]);
  const [dialogVisible, setDialogVisible] = useState(false);
  const [newPastaName, setNewPastaName] = useState('');

  const loadPastas = async () => {
    try {
      const fetchedPastas = await getPastas();
      setPastas(fetchedPastas);
    } catch (error) {
      console.error("Erro ao carregar pastas:", error);
      Alert.alert("Erro", "Não foi possível carregar as pastas.");
    }
  };

  useFocusEffect(
    useCallback(() => {
      loadPastas();
    }, [])
  );

  const showDialog = () => setDialogVisible(true);
  const hideDialog = () => setDialogVisible(false);

  const handleAddPasta = async () => {
    if (!newPastaName.trim()) {
      Alert.alert("Atenção", "O nome da pasta não pode ser vazio.");
      return;
    }
    try {
      const newId = await addPasta(newPastaName.trim());
      console.log('Nova pasta adicionada com ID:', newId);
      setNewPastaName('');
      hideDialog();
      loadPastas();
    } catch (error) {
      console.error("Erro ao adicionar pasta:", error);
      Alert.alert("Erro", "Não foi possível adicionar a pasta.");
    }
  };

  // NOVA FUNÇÃO: Lidar com a exclusão de pastas
  const handleDeletePasta = (pastaId, pastaNome) => {
    Alert.alert(
      "Confirmar Exclusão",
      `Tem certeza que deseja excluir a pasta "${pastaNome}"? Todas as músicas e tons associados também serão removidos.`,
      [
        { text: "Cancelar", style: "cancel" },
        {
          text: "Excluir",
          onPress: async () => {
            try {
              await deletePasta(pastaId);
              Alert.alert("Sucesso", "Pasta excluída com sucesso!");
              loadPastas(); // Recarrega a lista de pastas
            } catch (error) {
              console.error("Erro ao excluir pasta:", error);
              Alert.alert("Erro", "Não foi possível excluir a pasta.");
            }
          },
          style: "destructive", // Estilo de botão vermelho para ações destrutivas
        },
      ]
    );
  };

  const handleImportDb = async () => {
      Alert.alert(
          "Importar Banco de Dados",
          "Isso substituirá o banco de dados atual. Deseja continuar?",
          [
              { text: "Cancelar", style: "cancel" },
              {
                  text: "Importar",
                  onPress: async () => {
                      const imported = await importDatabaseFromFile();
                      if (imported) {
                          Alert.alert("Importação Concluída", "Banco de dados importado com sucesso! Por favor, feche e reabra o aplicativo para carregar os novos dados.");
                      }
                  },
              },
          ]
      );
  };


  // Adiciona um botão de importação no cabeçalho
  useEffect(() => {
    navigation.setOptions({
      headerRight: () => (
        <Appbar.Action icon="database-import" onPress={handleImportDb} />
      ),
    });
  }, [navigation]);


  return (
    <View style={styles.container}>
      <FlatList
        data={pastas}
        keyExtractor={(item) => item.Id.toString()}
        renderItem={({ item }) => (
          <List.Item
            title={item.Nome}
            description={`ID: ${item.Id}`}
            left={() => <List.Icon icon="folder" />}
            right={() => ( // Adicionando ações à direita
                <View style={styles.listItemActions}>
                    <IconButton
                        icon="delete"
                        onPress={() => handleDeletePasta(item.Id, item.Nome)}
                        color="red"
                        size={25} // Tamanho um pouco maior para ser mais visível
                    />
                </View>
            )}
            onPress={() => navigation.navigate('Musicas', { pastaId: item.Id, pastaNome: item.Nome })}
            style={styles.listItem} // Adicionando estilo para List.Item
          />
        )}
        ListEmptyComponent={<List.Item title="Nenhuma pasta encontrada. Crie uma!" />}
      />

      <FAB
        style={styles.fab}
        icon="plus"
        label="Nova Pasta"
        onPress={showDialog}
      />

      <Portal>
        <Dialog visible={dialogVisible} onDismiss={hideDialog}>
          <Dialog.Title>Nova Pasta</Dialog.Title>
          <Dialog.Content>
            <TextInput
              label="Nome da Pasta"
              value={newPastaName}
              onChangeText={setNewPastaName}
              mode="outlined"
            />
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={hideDialog}>Cancelar</Button>
            <Button onPress={handleAddPasta}>Criar</Button>
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
  listItem: { // Novo estilo para alinhar melhor o conteúdo
    paddingVertical: 0,
    marginVertical: 4, // Um pouco de espaço entre os itens
  },
  listItemActions: {
    flexDirection: 'row',
    alignItems: 'center',
    // Pode ajustar o marginRight se sentir que está muito grudado na borda
  },
  fab: {
    position: 'absolute',
    margin: 16,
    right: 0,
    bottom: 50,
  },
});