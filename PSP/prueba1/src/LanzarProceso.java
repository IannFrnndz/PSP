public class LanzarProceso {

    public static void main(String[] args) {
        try {
            // Usamos Runtime para ejecutar un proceso externo (en este caso, la calculadora)
            Process proceso = Runtime.getRuntime().exec("calc.exe");
            System.out.println("Proceso lanzado: calculadora");
        } catch (Exception e) {
            // En caso de que ocurra algún error al lanzar el proceso
            e.printStackTrace();
        }

    }
}
