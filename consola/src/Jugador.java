import java.util.Random;
import java.util.Scanner;

public class Jugador {
        Menu menu = new Menu();
        int n_palos = 21;
        String simboloPalos ="&";

        public void iniciarJuego() {
            System.out.println("Juego de 21 palos");
            imprimir();

            while (n_palos >1) {
                turnoJugador();
                if(n_palos < 1) break;
                turnoJugador2();
                if(n_palos < 1) break;
                turnoJugador3();
                if(n_palos < 1) break;
            }
            perder();
        }
        Random random = new Random();
        Scanner sc = new Scanner(System.in);

        public void cambiarFicha(){
            System.out.println("Ingresa el nuevo simbolo para los palos: ");
            simboloPalos = sc.nextLine();
        }

        public void imprimir() {
            for (int i = 0; i < n_palos ; i++) {
                System.out.print(simboloPalos);
                if((i+1) % 5 ==0 ){
                    System.out.print(" ");
                }
            }
        }



        public void turnoJugador(){
            System.out.println("\n\nJUGADOR 1: "+ n_palos +" palos restantes");
            System.out.println("\nCuantos palos deseas quitar?(solo podrás quitar de 1 a 4): ");
            int jugador = sc.nextInt();

            if (jugador >= 1 && jugador <= 4) {
                n_palos = n_palos - jugador;
            }else if (jugador < 1 || jugador > 4) {
                System.out.println("Número inválido, por favor ingresa un número entre 1 y 4.");
                turnoJugador();
            }

            this.imprimir();

        }

        public void turnoJugador2() {
            System.out.println("\n\nJUGADOR 2: "+ n_palos +" palos restantes");
            System.out.println("\nCuantos palos deseas quitar?(solo podrás quitar de 1 a 4): ");
            int jugador = sc.nextInt();

            if (jugador >= 1 && jugador <= 4) {
                n_palos = n_palos - jugador;
            }else if (jugador < 1 || jugador > 4) {
                System.out.println("Número inválido, por favor ingresa un número entre 1 y 4.");
                turnoJugador();
            }

            this.imprimir();
        }

        public void turnoJugador3(){
            System.out.println("\n\nJUGADOR 3: "+ n_palos +" palos restantes");
            System.out.println("\nCuantos palos deseas quitar?(solo podrás quitar de 1 a 4): ");
            int jugador = sc.nextInt();

            if (jugador >= 1 && jugador <= 4) {
                n_palos = n_palos - jugador;
            }else if (jugador < 1 || jugador > 4) {
                System.out.println("Número inválido, por favor ingresa un número entre 1 y 4.");
                turnoJugador();
            }

            this.imprimir();

        }


        public void perder(){
            System.out.println("\n\nHas perdido :)");

            System.out.println("\n\nDeseas jugar de nuevo? si es asi presiona R, de lo contrario presiona cualquier otra tecla");
            String opcion = sc.next();

            // si al acabar el juego el jugador pulsa R, se reinicia el juego
            if (opcion.equalsIgnoreCase("R")) {
                n_palos = 21;
                iniciarJuego();

                // En caso de que el jugador meta cualquier otra cosa que no sea R o enter
            } else {
                menu.mostrarMenu();
            }
        }

    }

