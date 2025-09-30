using System;
using System.Collections.Generic;

// Step 1: Observer Interface
interface IObserver
{
    void Update(float temperature);
}

// Step 2: Subject (Weather Station)
class WeatherStation
{
    private List<IObserver> observers = new List<IObserver>();
    private float temperature;

    public void AddObserver(IObserver observer) => observers.Add(observer);
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);

    public void SetTemperature(float temp)
    {
        Console.WriteLine($"WeatherStation: New temperature = {temp}");
        temperature = temp;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var obs in observers)
        {
            obs.Update(temperature);
        }
    }
}

// Step 3: Concrete Observers
class MobileApp : IObserver
{
    public void Update(float temperature)
    {
        Console.WriteLine($"MobileApp: Temperature updated to {temperature}");
    }
}

class LEDDisplay : IObserver
{
    public void Update(float temperature)
    {
        Console.WriteLine($"LEDDisplay: Temperature updated to {temperature}");
    }
}

// Step 4: Demo
class Program1
{
    static void Main()
    {
        WeatherStation station = new WeatherStation();

        MobileApp mobile = new MobileApp();
        LEDDisplay display = new LEDDisplay();

        station.AddObserver(mobile);
        station.AddObserver(display);

        station.SetTemperature(30.5f);
        station.SetTemperature(32.0f);
    }
}
