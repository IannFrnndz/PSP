public class Numeros {
    public static void main(String[] args) {
        if (args.length < 1) {
            System.err.println("Uso: java Numeros <base>");
            System.exit(1);
        }
        int base;
        try {
            base = Integer.parseInt(args[0]);
            if (base <= 0) throw new NumberFormatException();
        } catch (NumberFormatException e) {
            System.err.println("La base debe ser un entero positivo.");
            System.exit(1);
            return;
        }

        String filename = "triangulo_" + base + ".txt";
        try (java.io.PrintWriter out = new java.io.PrintWriter(new java.io.FileWriter(filename))) {
            for (int row = base; row >= 1; row--) {
                for (int j = 1; j <= row; j++) {
                    out.print(j);
                }
                out.println();
            }
            System.out.println("Generado: " + filename);
        } catch (java.io.IOException e) {
            System.err.println("Error al escribir el archivo: " + e.getMessage());
            System.exit(2);
        }
    }
}
