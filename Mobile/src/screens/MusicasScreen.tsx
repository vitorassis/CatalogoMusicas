import React, { useState, useEffect, useCallback } from 'react';
import { StyleSheet, View, FlatList, Alert } from 'react-native';
import { FAB, List, Portal, Dialog, Button, TextInput, IconButton, Text, Divider, MD3Colors } from 'react-native-paper';
import { useFocusEffect } from '@react-navigation/native';
import { getMusicasByPasta, addMusica, updateMusica, deleteMusica, getTonsByMusica } from '../database';

export default function MusicasScreen({ route, navigation }) {
  const { pastaId, pastaNome } = route.params;
  const [musicas, setMusicas] = useState([]);
  const [filteredMusicas, setFilteredMusicas] = useState([]);
  const [searchQuery, setSearchQuery] = useState('');
  
  // Diálogo para adicionar/editar música
  const [dialogVisible, setDialogVisible] = useState(false);
  const [newMusicaName, setNewMusicaName] = useState('');
  const [newMusicaIndex, setNewMusicaIndex] = useState(''); // Estado para o índice
  const [originalTone, setOriginalTone] = useState('');
  const [editingMusica, setEditingMusica] = useState(null);

  // Diálogo para trocar índices
  const [swapDialogVisible, setSwapDialogVisible] = useState(false);
  const [index1, setIndex1] = useState('');
  const [index2, setIndex2] = useState('');

  const loadMusicas = async () => {
    try {
      const fetchedMusicas = await getMusicasByPasta(pastaId);
      const musicasWithTons = await Promise.all(
        fetchedMusicas.map(async (musica) => {
          const tons = await getTonsByMusica(musica.Id);
          return { ...musica, tons: tons.map(t => t.Tonalidade).join(', ') };
        })
      );
      setMusicas(musicasWithTons);
      setFilteredMusicas(musicasWithTons);
    } catch (error) {
      console.error("Erro ao carregar músicas:", error);
      Alert.alert("Erro", "Não foi possível carregar as músicas.");
    }
  };

  useFocusEffect(
    useCallback(() => {
      loadMusicas();
    }, [pastaId])
  );

  useEffect(() => {
    navigation.setOptions({
      title: pastaNome || 'Músicas',
      // Adiciona o botão de troca de índice na barra superior
      headerRight: () => (
        <IconButton icon="swap-horizontal" onPress={() => setSwapDialogVisible(true)} />
      ),
    });
  }, [pastaNome, navigation]);

  useEffect(() => {
    if (searchQuery.trim() === '') {
      setFilteredMusicas(musicas);
    } else {
      const lowerCaseQuery = searchQuery.toLowerCase();
      const filtered = musicas.filter(musica =>
        musica.Nome.toLowerCase().includes(lowerCaseQuery)
      );
      setFilteredMusicas(filtered);
    }
  }, [searchQuery, musicas]);

  // Funções do Diálogo de Adicionar/Editar Música
  const showMusicaDialog = (musica = null) => {
    setEditingMusica(musica);
    setNewMusicaName(musica ? musica.Nome : '');
    setNewMusicaIndex(musica ? String(musica.Indice) : ''); // Preenche o índice
    setOriginalTone(''); // Tom original é apenas para a criação
    setDialogVisible(true);
  };

  const hideMusicaDialog = () => {
    setDialogVisible(false);
    setEditingMusica(null);
    setNewMusicaName('');
    setNewMusicaIndex('');
    setOriginalTone('');
  };

  const handleSaveMusica = async () => {
    if (!newMusicaName.trim()) {
      Alert.alert("Atenção", "O nome da música não pode ser vazio.");
      return;
    }
    const parsedIndex = parseInt(newMusicaIndex, 10);
    if (isNaN(parsedIndex) || parsedIndex <= 0) {
        Alert.alert("Atenção", "O índice da música deve ser um número inteiro positivo.");
        return;
    }

    try {
      if (editingMusica) {
        // Atualizar música existente
        await updateMusica(editingMusica.Id, newMusicaName.trim(), parsedIndex, pastaId);
        Alert.alert("Sucesso", "Música atualizada!");
      } else {
        // Adicionar nova música
        const newMusicaId = await addMusica(newMusicaName.trim(), parsedIndex, pastaId);

        if (originalTone.trim()) {
          await addTom(newMusicaId, originalTone.trim());
        }
        Alert.alert("Sucesso", "Música adicionada!");
      }
      hideMusicaDialog();
      loadMusicas();
    } catch (error) {
      console.error("Erro ao salvar música:", error);
      Alert.alert("Erro", "Não foi possível salvar a música.");
    }
  };

  const handleDeleteMusica = (musicaId) => {
    Alert.alert(
      "Confirmar Exclusão",
      "Tem certeza que deseja excluir esta música e todos os seus tons associados?",
      [
        { text: "Cancelar", style: "cancel" },
        {
          text: "Excluir",
          onPress: async () => {
            try {
              await deleteMusica(musicaId);
              Alert.alert("Sucesso", "Música excluída!");
              loadMusicas();
            } catch (error) {
              console.error("Erro ao excluir música:", error);
              Alert.alert("Erro", "Não foi possível excluir a música.");
            }
          },
          style: "destructive",
        },
      ]
    );
  };

  // Funções do Diálogo de Trocar Índices
  const hideSwapDialog = () => {
    setSwapDialogVisible(false);
    setIndex1('');
    setIndex2('');
  };

  const handleSwapIndices = async () => {
    const idx1 = parseInt(index1, 10);
    const idx2 = parseInt(index2, 10);

    if (isNaN(idx1) || isNaN(idx2) || idx1 <= 0 || idx2 <= 0 || idx1 === idx2) {
      Alert.alert("Atenção", "Por favor, insira dois índices inteiros positivos e diferentes.");
      return;
    }

    const musica1 = musicas.find(m => m.Indice === idx1);
    const musica2 = musicas.find(m => m.Indice === idx2);

    if (!musica1 || !musica2) {
      Alert.alert("Erro", "Um ou ambos os índices não correspondem a músicas existentes.");
      return;
    }

    try {
      // Troca os índices no banco de dados
      await updateMusica(musica1.Id, musica1.Nome, idx2, pastaId);
      await updateMusica(musica2.Id, musica2.Nome, idx1, pastaId);
      Alert.alert("Sucesso", "Músicas trocadas de posição!");
      hideSwapDialog();
      loadMusicas(); // Recarrega a lista com a nova ordem
    } catch (error) {
      console.error("Erro ao trocar índices:", error);
      Alert.alert("Erro", "Não foi possível trocar as posições das músicas.");
    }
  };

  return (
    <View style={styles.container}>
      <TextInput
        label="Buscar música"
        value={searchQuery}
        onChangeText={setSearchQuery}
        mode="outlined"
        style={styles.searchBar}
        left={<TextInput.Icon icon="magnify" />}
        clearButtonMode="always"
      />
      <Divider style={styles.divider} />

      <FlatList
        data={filteredMusicas}
        keyExtractor={(item) => item.Id.toString()}
        renderItem={({ item }) => (
          <List.Item
            title={
              <View style={styles.titleContainer}>
                <Text style={styles.indexText}>{item.Indice}. </Text>
                <Text style={styles.musicaNameText}>{item.Nome}</Text>
              </View>
            }
            description={item.tons ? `Tons: ${item.tons}` : 'Sem tons cadastrados'}
            left={() => <List.Icon icon="music" />}
            right={() => (
              <View style={styles.listItemActions}>
                <IconButton
                  icon="pencil"
                  onPress={() => showMusicaDialog(item)}
                  size={20}
                />
                <IconButton
                  icon="delete"
                  onPress={() => handleDeleteMusica(item.Id)}
                  color={MD3Colors.error50} // Cor vermelha do Material Design 3
                  size={20}
                />
                <IconButton
                  icon="note-plus-outline"
                  onPress={() => navigation.navigate('Tons', { musicaId: item.Id, musicaNome: item.Nome })}
                  size={20}
                />
              </View>
            )}
            style={styles.listItem}
          />
        )}
        ListEmptyComponent={<List.Item title="Nenhuma música encontrada." />}
      />

      <FAB
        style={styles.fab}
        icon="plus"
        label="Nova Música"
        onPress={() => showMusicaDialog()}
      />

      {/* Diálogo para Adicionar/Editar Música */}
      <Portal>
        <Dialog visible={dialogVisible} onDismiss={hideMusicaDialog}>
          <Dialog.Title>{editingMusica ? 'Editar Música' : 'Nova Música'}</Dialog.Title>
          <Dialog.Content>
            <TextInput
              label="Nome da Música"
              value={newMusicaName}
              onChangeText={setNewMusicaName}
              mode="outlined"
              style={styles.inputField}
            />
            <TextInput
              label="Índice"
              value={newMusicaIndex}
              onChangeText={setNewMusicaIndex}
              keyboardType="numeric" // Garante que o teclado numérico apareça
              mode="outlined"
              style={styles.inputField}
            />
            {!editingMusica && (
              <TextInput
                label="Tom Original (opcional)"
                value={originalTone}
                onChangeText={setOriginalTone}
                mode="outlined"
                placeholder="Ex: C, Am, G#"
                style={styles.inputField}
              />
            )}
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={hideMusicaDialog}>Cancelar</Button>
            <Button onPress={handleSaveMusica}>{editingMusica ? 'Salvar' : 'Adicionar'}</Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>

      {/* Diálogo para Trocar Índices */}
      <Portal>
        <Dialog visible={swapDialogVisible} onDismiss={hideSwapDialog}>
          <Dialog.Title>Trocar Músicas de Posição</Dialog.Title>
          <Dialog.Content>
            <TextInput
              label="Índice da Música 1"
              value={index1}
              onChangeText={setIndex1}
              keyboardType="numeric"
              mode="outlined"
              style={styles.inputField}
            />
            <TextInput
              label="Índice da Música 2"
              value={index2}
              onChangeText={setIndex2}
              keyboardType="numeric"
              mode="outlined"
              style={styles.inputField}
            />
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={hideSwapDialog}>Cancelar</Button>
            <Button onPress={handleSwapIndices}>Trocar</Button>
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
  searchBar: {
    margin: 8,
  },
  divider: {
    marginBottom: 8,
  },
  listItem: {
    paddingVertical: 0,
    marginVertical: 4,
  },
  titleContainer: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  indexText: {
    fontWeight: 'bold',
    fontSize: 18, // Tamanho maior para destacar
    color: MD3Colors.primary50, // Cor de destaque (ex: azul)
    marginRight: 5,
  },
  musicaNameText: {
    fontSize: 16,
    color: 'black'
  },
  listItemActions: {
    flexDirection: 'row',
    alignItems: 'center',
    marginRight: 10,
  },
  inputField: {
    marginBottom: 10,
  },
  fab: {
    position: 'absolute',
    margin: 16,
    right: 0,
    bottom: 50,
  },
});