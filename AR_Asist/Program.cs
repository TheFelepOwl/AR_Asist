using System;
using System.Collections.Generic;

public class MenuSingleton
{
    private static MenuSingleton instance;

    // Приватний конструктор, щоб заборонити зовнішнє створення екземплярів
    private MenuSingleton() { }

    // Статичний метод, який повертає єдиний екземпляр класу MenuSingleton
    public static MenuSingleton GetInstance()
    {
        if (instance == null)
        {
            instance = new MenuSingleton();
        }
        return instance;
    }

    // Методи для відкриття програм
    public void open_Note()
    {
        Console.WriteLine("Opening Note...");
    }

    public void open_Call()
    {
        Console.WriteLine("Opening Call...");
    }

    public void open_Map()
    {
        Console.WriteLine("Opening Map...");
    }

    public void open_Messenger()
    {
        Console.WriteLine("Opening Messenger...");
    }

    public void open_Health()
    {
        Console.WriteLine("Opening Health...");
    }

    public void open_Workout()
    {
        Console.WriteLine("Opening Workout...");
    }

    public void shutdown()
    {
        Console.WriteLine("Shutting down...");
    }
}
public class Note
{
    public string title { get; set; }
    public string content { get; set; }

    public string get_note_title()
    {
        return title;
    }

    public string get_note_content()
    {
        return content;
    }

    public void set_note_title(string new_title)
    {
        title = new_title;
    }

    public void set_note_content(string new_content)
    {
        content = new_content;
    }
}


public class Messenger
{
    public string sender { get; set; }
    public string receiver { get; set; }
    public string message_content { get; set; }

    public void send_message(string receiver, string content)
    {
    }

    public void read_message()
    {
    }

    public void delete_message()
    {
    }
}

public class Route
{
    public double start_point_x { get; set; }
    public double start_point_y { get; set; }
    public double end_point_x { get; set; }
    public double end_point_y { get; set; }
    public List<Tuple<double, double>> waypoints { get; set; }

    public void set_start_point(double point_y, double point_x)
    {
        start_point_x = point_x;
        start_point_y = point_y;
    }

    public void set_end_point(double point_x, double point_y)
    {
        end_point_x = point_x;
        end_point_y = point_y;
    }

    public void add_waypoint(double point_x, double point_y)
    {
        waypoints.Add(new Tuple<double, double>(point_x, point_y));
    }

    public void remove_waypoint(double point_x, double point_y)
    {
        waypoints.Remove(new Tuple<double, double>(point_x, point_y));
    }

    public string get_route()
    {
        return "";
    }
}
public interface IHealth
{
    void record_pulse(int pulse_value);
    void record_temperature(float temperature_value);
    void record_blood_oxygen_level(int oxygen_level);
    void record_stress_level(int stress_level);
}

// Клас FitnessTracker, який ми хочемо адаптувати
public class FitnessTracker
{
    public int daily_steps { get; set; }
    public int calories_burned { get; set; }
    public int pulse { get; private set; } // Додали властивість для зберігання пульсу

    public void record_pulse(int pulse_value)
    {
        pulse = pulse_value; // Записуємо значення пульсу
    }

    public int getCurrentPulse() // Метод для отримання поточного значення пульсу
    {
        return pulse;
    }

    public void record_temperature(float temperature_value)
    {
        // Логіка запису температури
    }

    // Додаткові методи та властивості класу FitnessTracker
}

// Адаптер для FitnessTracker, який реалізує інтерфейс IHealth
public class FitnessTrackerAdapter : IHealth
{
    private FitnessTracker fitnessTracker;

    public FitnessTrackerAdapter(FitnessTracker tracker)
    {
        fitnessTracker = tracker;
    }

    public void record_pulse(int pulse_value)
    {
        fitnessTracker.record_pulse(pulse_value);
    }

    public void record_temperature(float temperature_value)
    {
        fitnessTracker.record_temperature(temperature_value);
    }

    public void record_blood_oxygen_level(int oxygen_level)
    {
        // Додаткові логіка тут, якщо потрібно
    }

    public void record_stress_level(int stress_level)
    {
        // Додаткові логіка тут, якщо потрібно
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Отримання єдиного екземпляру класу MenuSingleton
        MenuSingleton menu = MenuSingleton.GetInstance();

        // Відкриття різних програм з меню
        menu.open_Note();
        menu.open_Call();
        menu.open_Map();
        menu.open_Messenger();
        menu.open_Health();
        menu.open_Workout();

        // Закриття програми
        menu.shutdown();


        // Створення екземпляру класу FitnessTracker
        FitnessTracker fitnessTracker = new FitnessTracker();

        // Створення адаптера для FitnessTracker
        IHealth healthAdapter = new FitnessTrackerAdapter(fitnessTracker);

        // Запис даних про пульс за допомогою адаптера
        healthAdapter.record_pulse(80);

        // Запис температури за допомогою адаптера
        healthAdapter.record_temperature(37.5f);

        int currentPulse = fitnessTracker.getCurrentPulse();

        // Виведення поточного пульсу у консоль
        Console.WriteLine("Current pulse: " + currentPulse);


    }
}