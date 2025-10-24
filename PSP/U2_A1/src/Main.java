public class Main {
    public static void main(String[] args) {
        HiloPrincipal hiloPrincipal = new HiloPrincipal();
        Thread thread = new Thread(hiloPrincipal);
        thread.start();
    }

}
