//using System;

//// Target
//interface ITypeCCharger
//{
//    void ChargePhone();
//}

//// Adaptee
//class MicroUSBCharger
//{
//    public void ChargeWithMicroUSB()
//    {
//        Console.WriteLine("Charging with Micro-USB Charger");
//    }
//}

//// Adapter
//class ChargerAdapter : ITypeCCharger
//{
//    private MicroUSBCharger _microUsbCharger;

//    public ChargerAdapter(MicroUSBCharger charger)
//    {
//        _microUsbCharger = charger;
//    }

//    public void ChargePhone()
//    {
//        _microUsbCharger.ChargeWithMicroUSB();
//    }
//}

//// Demo
//class Program5
//{
//    static void Main()
//    {
//        MicroUSBCharger oldCharger = new MicroUSBCharger();
//        ITypeCCharger adapter = new ChargerAdapter(oldCharger);

//        adapter.ChargePhone();
//    }
//}
