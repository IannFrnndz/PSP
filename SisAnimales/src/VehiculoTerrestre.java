public abstract class VehiculoTerrestre implements Vehiculo{
    protected int velocidad;
    protected int ruedas;

    public VehiculoTerrestre(int ruedas){
        this.ruedas = ruedas;
        this.velocidad= 0;
    }
    @Override
    public int obtenerVelocidad(){
        return velocidad;
    }

    @Override
    public abstract void acelerar();

    @Override
    public abstract void frenar();
}
