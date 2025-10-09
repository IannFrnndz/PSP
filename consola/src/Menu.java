public class Menu {
    java.util.Scanner sc = new java.util.Scanner(System.in);
    public void mostrarMenu() {
        System.out.println("=== Menú Principal ===");
        System.out.println("1. Jugar");
        System.out.println("2. Instrucciones");
        System.out.println("3. Cambiar ficha");
        System.out.println("4. Salir");
        System.out.print("Seleccione una opción: ");

        String simboloPalos ="&";

        int opcion = sc.nextInt();

        switch (opcion) {
            case 1:
                menuSecundario();
                break;
            case 2:
                System.out.println("\nInstrucciones:");
                System.out.println("\nEl juego consiste en tachar palitos (de 1 a 4) por turnos teniendo 21 palitos\n" +
                        "en total al inicio de la partida. El jugador o máquina que tache el último\n" +
                        "palito, pierde.\n\n" );
                mostrarMenu();
                break;
            case 3:
                System.out.println("Ingresa el nuevo simbolo para los palos: ");
                String nuevoSimbolo = sc.next();
                Jugador jugador = new Jugador();
                jugador.simboloPalos = nuevoSimbolo;
                System.out.println("El símbolo ha sido cambiado a: " + nuevoSimbolo);
                mostrarMenu();
                break;
            case 4:
                System.out.println("Estas saliendo del Juego :)");
                System.exit(0);
                break;
        }
    }

    public void menuSecundario() {
        System.out.println("=== Menú Secundario ===");
        System.out.println("1. Jugador VS Jugador VS Jugador");
        System.out.println("2. Jugador VS IA");
        System.out.println("3. Volver al Menú Principal");
        System.out.print("Seleccione una opción: ");

        int opcion = sc.nextInt();

        switch (opcion) {
            case 1:
                Jugador jugador = new Jugador();
                jugador.iniciarJuego();
                break;
            case 2:
                Consola consola = new Consola();
                consola.iniciarJuego();
                break;
            case 3:
                mostrarMenu();
                break;
        }

    }
}
