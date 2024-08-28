using MinimalApi.Models;

namespace MinimalApi.Interfaces;

public interface PeopleServiceInterface {
    string Create(Person person);
}

// an implementation of this interface
public class PeopleService : PeopleServiceInterface {
    public string Create(Person person){
        return person.FirstName + " " + person.LastName + " " + person.MiddleName;
    }
}