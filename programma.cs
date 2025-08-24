 public class Airline {
    public string name;
    
    public Plane []airline_planes;
    public Route []airline_routes;
    
    public Route createRoute(string departure, string arrival)  {
        Route newRoute;
        foreach (Plane plane in airline_planes) {
            bool freePlane = plane.isFree();
            if (freePlane) {
                newRoute = new Route(departure, arrival);
                break;
            }
        }
        return newRoute;
    }
}

public class Plane {
    public string model;
    
    public bool isFree() {}
}

public class Route {
    public string departure;
    public string arrival;

    public Route(string departure, string arrival) {}
}

public class Flight {
    public int seat_count;
    
    public Plane plane;
    public Route route;
    
    public void getInfo() {}
    public int checkFreeSeats() {}
}

public class Schedule {
    public string dateTime;
    public string gate;
    public string terminal;
    
    public Flight []flights;
    
    public Schedule(string date, string departure, string arrival) {}

    public string display() {}
    private void changeGate(string newGate) {}
    public Flight[] getFlights() {
        foreach (Flight flight in flights) {
            int hasPlace = flight.checkFreeSeats();
            if (hasPlace > 0) {
                return flight;
            }
        }
        return null;
    }
}

public class Passenger {
    public string name;
    public string surname;
    public string passport;
    
    public Ticket BuyTicket(Schedule s) {
        string data = s.display();
        Ticket ticket = new Ticket(data);
        return ticket;
    }

    public Flight GetFlight(string date, string departure, string arrival) {
        Schedule schedule = compute(date, departure, arrival);
        Flight f = schedule.getFlights();
        return f;
    }

    public Schedule compute(string date, string departure, string arrival) {
        Schedule newSchedule = new Schedule(date, departure, arrival);
        newSchedule.changeGate("B1");
        return newSchedule;
    }
}

public class Ticket {
    public Flight flight;
    public Passenger passenger;

    public Ticket(string data) {}
}

public class FirstClass : Ticket {
    public string first_seat;

    public FirstClass(string data) : base(data) {}
}

public class BusinessClass : Ticket {
    public string business_seat;

    public BusinessClass(string data) : base(data) {}
}