import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View, ActivityIndicator } from 'react-native';
import { PaperProvider } from 'react-native-paper';
import { initTables } from './src/database';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';

// Importe as telas
import PastasScreen from './src/screens/PastasScreen';
import MusicasScreen from './src/screens/MusicasScreen';
import TonsScreen from './src/screens/TonsScreen'; // Vamos criar esta em seguida

const Stack = createNativeStackNavigator();

export default function App() {
  const [dbInitialized, setDbInitialized] = useState(false);

  useEffect(() => {
    const initializeApp = async () => {
      try {
        await initTables();
        setDbInitialized(true);
        console.log("Banco de dados inicializado com sucesso.");
      } catch (error) {
        console.error("Erro ao inicializar o banco de dados:", error);
      }
    };
    initializeApp();
  }, []);

  if (!dbInitialized) {
    return (
      <View style={styles.loadingContainer}>
        <ActivityIndicator size="large" color="#0000ff" />
        <Text>Carregando banco de dados...</Text>
      </View>
    );
  }

  return (
    <SafeAreaProvider>
      <PaperProvider>
        <NavigationContainer>
          <Stack.Navigator initialRouteName="Pastas">
            <Stack.Screen
              name="Pastas"
              component={PastasScreen}
              options={{ title: 'Minhas Pastas' }}
            />
            <Stack.Screen
              name="Musicas"
              component={MusicasScreen}
              options={({ route }) => ({ title: route.params.pastaNome || 'Músicas' })} // Título dinâmico da pasta
            />
            <Stack.Screen
              name="Tons"
              component={TonsScreen}
              options={({ route }) => ({ title: `Tons de ${route.params.musicaNome}` })} // Título dinâmico da música
            />
          </Stack.Navigator>
        </NavigationContainer>
      </PaperProvider>
    </SafeAreaProvider>
  );
}

const styles = StyleSheet.create({
  loadingContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
});