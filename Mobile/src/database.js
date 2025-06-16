import * as SQLite from 'expo-sqlite';
import { Alert, Platform } from 'react-native';
import * as DocumentPicker from 'expo-document-picker';
import * as FileSystem from 'expo-file-system';

let db = null;


// Adicione ou modifique esta função para obter o caminho do banco de dados
// Esta função é uma heurística, pois o caminho exato pode variar por driver ou versão do Expo.
const getDatabaseFilePath = (dbName) => {
    // Expo SQLite (bare workflow ou EAS build) em Android/iOS geralmente coloca em:
    // FileSystem.documentDirectory + 'SQLite/' + dbName
    // Mas a API openDatabaseAsync pode usar outro caminho interno em algumas configurações.
    // A forma mais robusta é deletar e recriar, ou usar o asset loading para o DB inicial.

    // Para o nosso caso, vamos tentar o caminho padrão documentDirectory/SQLite/
    return `${FileSystem.documentDirectory}SQLite/${dbName}`;
};


/**
 * Fecha a conexão com o banco de dados (útil para testes ou reset).
 */
export const closeDb = async () => {
  if (db) {
    try {
      await db.closeAsync();
      console.log('Banco de dados fechado.');
      db = null; // Reseta a instância
    } catch (error) {
      console.error('Erro ao fechar o banco de dados:', error);
    }
  }
};

/**
 * Deleta o arquivo físico do banco de dados.
 * Isso resetará completamente todos os dados.
 */
export const deleteDbFile = async () => {
    if (Platform.OS === 'web') {
        console.warn('Excluir arquivo de DB não é suportado diretamente no Expo Web.');
        return;
    }
    await closeDb(); // Garante que a conexão está fechada antes de tentar deletar o arquivo
    try {
        const dbFileName = 'catalogadorMusicas.db';
        const dbPath = getDatabaseFilePath(dbFileName);

        const currentDbInfo = await FileSystem.getInfoAsync(dbPath);
        if (currentDbInfo.exists) {
            await FileSystem.deleteAsync(dbPath, { idempotent: true });
            console.log('Arquivo do banco de dados existente deletado com sucesso!');
        } else {
            console.log('Nenhum arquivo de banco de dados existente para deletar.');
        }
    } catch (error) {
        console.error('Erro ao deletar arquivo do banco de dados:', error);
    }
};

/**
 * Importa um arquivo .sqlite do dispositivo do usuário para o diretório de banco de dados do aplicativo.
 * Isso substituirá o banco de dados existente.
 * @returns {Promise<boolean>} True se a importação for bem-sucedida, false caso contrário.
 */
export const importDatabaseFromFile = async () => {
    try {
        const result = await DocumentPicker.getDocumentAsync({
            type: '*/*',
            copyToCacheDirectory: true,
        });

        if (result.canceled) {
            console.log('Seleção de arquivo cancelada.');
            return false;
        }

        const selectedFile = result.assets[0];
        const fileName = selectedFile.name;
        const fileUri = selectedFile.uri;

        if (!fileName.endsWith('.sqlite') && !fileName.endsWith('.db')) {
            Alert.alert('Erro de Arquivo', 'Por favor, selecione um arquivo .sqlite ou .db.');
            await FileSystem.deleteAsync(fileUri, { idempotent: true });
            return false;
        }

        const dbFileName = 'catalogadorMusicas.db';
        // Obtenha o caminho onde o expo-sqlite realmente espera o arquivo
        const dbPath = getDatabaseFilePath(dbFileName);

        // 1. Fechar a conexão atual com o DB
        await closeDb();

        // 2. Tentar deletar o arquivo de DB existente
        await deleteDbFile(); // Usamos a função auxiliar que já lida com o caminho e verificação de existência

        // 3. Garantir que o diretório 'SQLite' existe (se não existir, copyAsync falhará)
        const dbDirectory = `${FileSystem.documentDirectory}SQLite/`;
        const dirInfo = await FileSystem.getInfoAsync(dbDirectory);
        if (!dirInfo.exists) {
            console.log(`Criando diretório: ${dbDirectory}`);
            await FileSystem.makeDirectoryAsync(dbDirectory, { intermediates: true });
        }

        // 4. Copiar o arquivo selecionado para o local do banco de dados
        console.log(`Copiando ${fileUri} para ${dbPath}`);
        await FileSystem.copyAsync({
            from: fileUri,
            to: dbPath,
        });

        console.log(`Banco de dados ${fileName} importado com sucesso para ${dbPath}`);
        Alert.alert('Sucesso', 'Banco de dados importado com sucesso! Por favor, **reinicie o aplicativo** para ver as mudanças.');

        // Limpar o arquivo temporário da cache
        await FileSystem.deleteAsync(fileUri, { idempotent: true });
        
        return true;

    } catch (error) {
        console.error("Erro ao importar banco de dados:", error);
        Alert.alert('Erro', `Falha ao importar o banco de dados: ${error.message}.`);
        return false;
    }
};

/**
 * Retorna a instância do banco de dados SQLite.
 * Se a conexão ainda não foi aberta, ela será aberta.
 * @returns {Promise<SQLite.SQLiteDatabase>} A instância do banco de dados.
 */
export const getDb = async () => {
  if (db) {
    return db;
  }
  // No iOS e web, o nome do arquivo é usado como identificador.
  // No Android, o nome do arquivo é o nome do arquivo de banco de dados real.
  db = await SQLite.openDatabaseAsync('catalogadorMusicas.db');
  console.log('Banco de dados aberto/conectado.');
  return db;
};

/**
 * Inicializa as tabelas no banco de dados, se elas não existirem.
 * Inclui as tabelas Pastas, Musicas e Tons, e seus índices.
 */
export const initTables = async () => {
  const database = await getDb();
  await database.execAsync(`
    PRAGMA journal_mode = WAL; -- Melhora a concorrência e resiliência

    CREATE TABLE IF NOT EXISTS "Pastas" (
        "Id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
        "Nome" TEXT NOT NULL
    );

    CREATE TABLE IF NOT EXISTS "Musicas" (
        "Id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
        "Nome" TEXT NOT NULL,
        "Indice" INTEGER NOT NULL,
        "PastaId" INTEGER NOT NULL,
        FOREIGN KEY("PastaId") REFERENCES "Pastas"("Id") ON DELETE CASCADE
    );

    CREATE TABLE IF NOT EXISTS "Tons" (
        "Id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
        "MusicaId" INTEGER NOT NULL,
        "Tonalidade" TEXT NOT NULL,
        FOREIGN KEY("MusicaId") REFERENCES "Musicas"("Id") ON DELETE CASCADE
    );

    CREATE INDEX IF NOT EXISTS "IX_Musicas_PastaId" ON "Musicas" (
        "PastaId"
    );

    CREATE INDEX IF NOT EXISTS "IX_Tons_MusicaId" ON "Tons" (
        "MusicaId"
    );
  `);
  console.log('Tabelas inicializadas com sucesso!');
};

/**
 * Obtém todas as pastas do banco de dados.
 * @returns {Promise<Array<Object>>} Uma array de objetos representando as pastas.
 */
export const getPastas = async () => {
  const database = await getDb();
  // getAllAsync retorna todas as linhas que correspondem à query.
  const allRows = await database.getAllAsync('SELECT * FROM Pastas ORDER BY Nome COLLATE NOCASE ASC;');
  return allRows;
};

/**
 * Adiciona uma nova pasta ao banco de dados.
 * @param {string} nome - O nome da nova pasta.
 * @returns {Promise<number>} O ID da nova pasta inserida.
 */
export const addPasta = async (nome) => {
  const database = await getDb();
  // runAsync executa uma query que não retorna dados (INSERT, UPDATE, DELETE).
  // O objeto retornado contém lastInsertRowId para INSERTs.
  const result = await database.runAsync('INSERT INTO Pastas (Nome) VALUES (?);', nome);
  return result.lastInsertRowId;
};

/**
 * Atualiza o nome de uma pasta existente.
 * @param {number} id - O ID da pasta a ser atualizada.
 * @param {string} novoNome - O novo nome da pasta.
 * @returns {Promise<number>} O número de linhas afetadas.
 */
export const updatePasta = async (id, novoNome) => {
  const database = await getDb();
  const result = await database.runAsync('UPDATE Pastas SET Nome = ? WHERE Id = ?;', novoNome, id);
  return result.changes; // Retorna o número de linhas modificadas
};

/**
 * Deleta uma pasta pelo seu ID.
 * Devido ao ON DELETE CASCADE, todas as músicas e seus tons associados também serão deletados.
 * @param {number} id - O ID da pasta a ser deletada.
 * @returns {Promise<number>} O número de linhas afetadas.
 */
export const deletePasta = async (id) => {
  const database = await getDb();
  const result = await database.runAsync('DELETE FROM Pastas WHERE Id = ?;', id);
  return result.changes;
};

// --- Funções CRUD para a tabela Musicas ---

/**
 * Obtém todas as músicas de uma pasta específica, ordenadas pelo índice.
 * @param {number} pastaId - O ID da pasta.
 * @returns {Promise<Array<Object>>} Uma array de objetos representando as músicas.
 */
export const getMusicasByPasta = async (pastaId) => {
  const database = await getDb();
  const allRows = await database.getAllAsync('SELECT * FROM Musicas WHERE PastaId = ? ORDER BY Indice ASC;', pastaId);
  return allRows;
};

/**
 * Adiciona uma nova música a uma pasta.
 * @param {string} nome - O nome da música.
 * @param {number} indice - O índice da música dentro da pasta.
 * @param {number} pastaId - O ID da pasta à qual a música pertence.
 * @returns {Promise<number>} O ID da nova música inserida.
 */
export const addMusica = async (nome, indice, pastaId) => {
  const database = await getDb();
  const result = await database.runAsync('INSERT INTO Musicas (Nome, Indice, PastaId) VALUES (?, ?, ?);', nome, indice, pastaId);
  return result.lastInsertRowId;
};

/**
 * Atualiza os dados de uma música existente.
 * @param {number} id - O ID da música a ser atualizada.
 * @param {string} nome - O novo nome da música.
 * @param {number} indice - O novo índice da música.
 * @param {number} pastaId - O ID da pasta (útil se a música puder ser movida entre pastas).
 * @returns {Promise<number>} O número de linhas afetadas.
 */
export const updateMusica = async (id, nome, indice, pastaId) => {
  const database = await getDb();
  const result = await database.runAsync('UPDATE Musicas SET Nome = ?, Indice = ?, PastaId = ? WHERE Id = ?;', nome, indice, pastaId, id);
  return result.changes;
};

/**
 * Deleta uma música pelo seu ID.
 * Devido ao ON DELETE CASCADE, todos os tons associados a esta música também serão deletados.
 * @param {number} id - O ID da música a ser deletada.
 * @returns {Promise<number>} O número de linhas afetadas.
 */
export const deleteMusica = async (id) => {
  const database = await getDb();
  const result = await database.runAsync('DELETE FROM Musicas WHERE Id = ?;', id);
  return result.changes;
};

// --- Funções CRUD para a tabela Tons ---

/**
 * Obtém todos os tons de uma música específica.
 * @param {number} musicaId - O ID da música.
 * @returns {Promise<Array<Object>>} Uma array de objetos representando os tons.
 */
export const getTonsByMusica = async (musicaId) => {
  const database = await getDb();
  const allRows = await database.getAllAsync('SELECT * FROM Tons WHERE MusicaId = ?;', musicaId);
  return allRows;
};

/**
 * Adiciona um novo tom a uma música.
 * @param {number} musicaId - O ID da música à qual o tom pertence.
 * @param {string} tonalidade - A tonalidade (ex: "C", "Am").
 * @returns {Promise<number>} O ID do novo tom inserido.
 */
export const addTom = async (musicaId, tonalidade) => {
  const database = await getDb();
  const result = await database.runAsync('INSERT INTO Tons (MusicaId, Tonalidade) VALUES (?, ?);', musicaId, tonalidade);
  return result.lastInsertRowId;
};

/**
 * Atualiza a tonalidade de um tom existente.
 * @param {number} id - O ID do tom a ser atualizado.
 * @param {string} novaTonalidade - A nova tonalidade.
 * @returns {Promise<number>} O número de linhas afetadas.
 */
export const updateTom = async (id, novaTonalidade) => {
  const database = await getDb();
  const result = await database.runAsync('UPDATE Tons SET Tonalidade = ? WHERE Id = ?;', novaTonalidade, id);
  return result.changes;
};

/**
 * Deleta um tom pelo seu ID.
 * @param {number} id - O ID do tom a ser deletado.
 * @returns {Promise<number>} O número de linhas afetadas.
 */
export const deleteTom = async (id) => {
  const database = await getDb();
  const result = await database.runAsync('DELETE FROM Tons WHERE Id = ?;', id);
  return result.changes;
};