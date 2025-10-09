public class Coche extends VehiculoTerrestre{
    boolean tieneAireAcondicionado;

    @Override
    public void acelerar() {
        velocidad = velocidad+10;
    }

    @Override
    public void frenar() {
        velocidad = velocidad -5;
    }

    public Coche(int ruedas, boolean tieneAireAcondicionado){
        super(ruedas);
        this.tieneAireAcondicionado = tieneAireAcondicionado;
    }

    public void setAireAcondicionado(boolean estado) {
        this.tieneAireAcondicionado = estado;
        if (estado) {
            System.out.println("Aire acondicionado activado.");
        } else {
            System.out.println("Aire acondicionado desactivado.");
        }
    }

    public boolean estaEncendido(){
        return tieneAireAcondicionado;
    }
}
