public class Corredor extends Thread {
    private String nombre;
    private static boolean hayGanador = false;

    public Corredor(String nombre) {
        this.nombre = nombre;
    }

    @Override
    public void run() {
        for (int i = 1; i <= 3; i++) {

            System.out.println(nombre + " va por el paso " + i);

            try {
                // este math random va a hacer que cada corredor tenga una velocidad diferente, con los hilos dormidos
                Thread.sleep((int) (Math.random() * 500));
            } catch (InterruptedException e) {
                e.getMessage();
            }
        }

        if (!hayGanador) {
            hayGanador = true;
            System.out.println( nombre + " ha ganado la carrera!");
        } else {
            System.out.println(nombre + " ha terminado");
        }
    }
}

class Ej2{
    public static void main(String[] args) {
        Corredor c1 = new Corredor("Corredor 1");
        Corredor c2 = new Corredor("Corredor 2");
        Corredor c3 = new Corredor("Corredor 3");

        c1.start();
        c2.start();
        c3.start();
    }
}
