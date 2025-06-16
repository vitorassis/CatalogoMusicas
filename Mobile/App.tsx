import { enableScreens } from 'react-native-screens'; // Adicione esta linha
enableScreens(); // Adicione esta linha (logo abaixo da importação)

import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View, ActivityIndicator } from 'react-native';
import { PaperProvider } from 'react-native-paper';
import { initTables } from './src/database';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';

import * as SplashScreen from 'expo-splash-screen'; // Adicione a importação
SplashScreen.preventAutoHideAsync(); // No topo do App.tsx, antes de export default

// Importe as telas
import PastasScreen from './src/screens/PastasScreen';
import MusicasScreen from './src/screens/MusicasScreen';
import TonsScreen from './src/screens/TonsScreen'; // Vamos criar esta em seguida

const Stack = createNativeStackNavigator();

export default function App() {
  const [dbInitialized, setDbInitialized] = useState(false);
  const [appIsReady, setAppIsReady] = useState(false); // Novo estado

  useEffect(() => {
    async function prepareApp() {
      try {
        await initTables(); // Se initTables falhar, o app ainda fica pronto para mostrar a tela de erro
      } catch (e) {
        console.warn(e);
        // Poderia mostrar um alerta ou uma tela de erro aqui
      } finally {
        setDbInitialized(true); // Indica que a tentativa de DB terminou
        setAppIsReady(true); // Indica que o app está pronto para renderizar (mesmo que com erro do DB)
        await SplashScreen.hideAsync(); // Esconde a splash screen
      }
    }
    prepareApp();
  }, []);

  if (!dbInitialized) {
    return (
      <View style={styles.loadingContainer}>
        <ActivityIndicator size="large" color="#0000ff" />
        <Text>Carregando banco de dados...</Text>
      </View>
    );
  }
  if (!appIsReady) { // Mudamos a condição para appIsReady
    return (
      <View style={styles.loadingContainer}>
        <ActivityIndicator size="large" color="#0000ff" />
        <Text>Carregando aplicativo...</Text>
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