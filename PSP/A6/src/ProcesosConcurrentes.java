public class ProcesosConcurrentes {
    public static void main(String[] args) {
        int[] bases = {5, 6, 7}; // bases diferentes para cada proceso
        String classpath = System.getProperty("java.class.path");
        java.util.List<Process> procesos = new java.util.ArrayList<>();

        for (int b : bases) {
            ProcessBuilder pb = new ProcessBuilder("java", "-cp", classpath, "Numeros", String.valueOf(b));
            pb.redirectErrorStream(true);
            pb.inheritIO(); // muestra en consola los mensajes del proceso hijo (opcional)
            try {
                procesos.add(pb.start());
            } catch (java.io.IOException e) {
                System.err.println("No se pudo iniciar el proceso para base " + b + ": " + e.getMessage());
            }
        }

        // Esperar a que terminen todos los procesos
        for (Process p : procesos) {
            try {
                int exit = p.waitFor();
                System.out.println("Proceso terminado con código de salida: " + exit);
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
                System.err.println("Espera interrumpida.");
            }
        }
    }
}
