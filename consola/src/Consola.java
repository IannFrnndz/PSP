import java.util.Random;
import java.util.Scanner;

public class Consola {
Menu menu = new Menu();
        int n_palos = 21;
        String ultimoEnJugar = "";
        public void iniciarJuego() {
            System.out.println("Juego de 21 palos");
            imprimir();

            while (n_palos >=1) {

                // iniciamos el turno del jugador e inicializamos que la variable ultimoEnJugar sea jugador para en caso de que sea el ultimo en jugar
                // pierda y asi se corte el bucle while con el break
                turnoJugador();
                ultimoEnJugar = "jugador";
                if(n_palos < 1) break;

                // hacemos lo mismo con la maquina
                turnoMaquina();
                ultimoEnJugar= "maquina";
                if(n_palos < 1) break;

            }
            // si se rompe el bucle while se llama a la funcion perder
            perder();
        }
        Random random = new Random();
        Scanner sc = new Scanner(System.in);

        public void imprimir() {
            for (int i = 0; i < n_palos; i++) {
                System.out.print("&");
                // condicion para que cada 5 palos haya un espacio
                if((i+1) % 5 ==0 ){
                    System.out.print(" ");
                }
            }
        }

        // el turno del jugador ( tiene que empezar para ganar)
        public void turnoJugador(){
            System.out.println("\n\nJUGADOR: "+ n_palos +" palos restantes");
            System.out.println("\nCuantos palos deseas quitar?(solo podrás quitar de 1 a 4): ");
            int jugador = sc.nextInt();

            // mientras  el numero de palos que qquiera quitar el jugador sea mmayor que 1 y menor que 4 se lo restamos a los palos totales
            if (jugador >= 1 && jugador <= 4) {
                n_palos = n_palos - jugador;
                // en cambio si el numero es menor que 1 o mayor que 4 le decimos que es invalido y volvemos a llamar a la funcion
            }else if (jugador < 1 || jugador > 4) {
                System.out.println("Número inválido, por favor ingresa un número entre 1 y 4.");
                turnoJugador();
            }
            // imprimimos los palos restantes
            this.imprimir();

        }

        public void turnoMaquina() {
            int n;
            // si el numero de palos es menor o igual a 4, la maquina quita todos menos 1
            if (n_palos <= 4) {
                n = n_palos - 2;
                if (n < 1) n = 1;
            } else {
                int resto = (n_palos - 1) % 5;
                if (resto == 0) {
                    n = 1 + random.nextInt(4);
                } else {
                    n = resto;
                }
            }

            System.out.println("\n\nTURNO DE LA MAQUINA: " + n_palos + " palos restantes");
            System.out.println("\nLa máquina va a quitar *" + n + "* palos");

            n_palos -= n;
            this.imprimir();
        }


        public void perder(){
            // creamos la funcion para perder en funcion de quien fue el ultimo en jugar
            if (n_palos < 1) {
                if (ultimoEnJugar.equals("maquina"))
                    System.out.println("\n\nLa maquina ha perdido :)");
                else if (ultimoEnJugar.equals("jugador")) {
                    System.out.println("\n\nEl jugador ha perdido :)");
                }

            }

            // si se preseiona R se reinicia el juego
            System.out.println("\n\nDeseas jugar de nuevo? si es asi presiona R, de lo contrario presiona cualquier otra tecla");
            String opcion = sc.next();
            if (opcion.equalsIgnoreCase("R")) {
                n_palos = 21;
                iniciarJuego();

                // En caso de que el jugador meta cualquier otra cosa que no sea R
            } else {
                menu.mostrarMenu();
            }
        }

}


