using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge =
        new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person() { Email = email, Age = age, Name = name, Town = town };

        // Add by email
        this.personsByEmail.Add(email, person);

        // Add by email domain name
        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain.AppendValueToKey(emailDomain, person);

        // Add by name and town
        var nameTownKey = this.CombineNameAndTown(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameTownKey, person);

        // Add by age
        this.personsByAge.AppendValueToKey(age, person);

        // Add by town and age
        this.personsByTownAndAge.EnsureKeyExists(town);
        this.personsByTownAndAge[town].AppendValueToKey(age, person);

        return true;
    }

    public int Count
    {
        get { return this.personsByEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        Person person;
        var personExists = this.personsByEmail.TryGetValue(email, out person);

        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);

        if (person == null)
        {
            return false;
        }

        // Remove by email
        var personDeleted = this.personsByEmail.Remove(email);

        // Remove by email domain name
        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain[emailDomain].Remove(person);

        // Remove by town and name
        string townNameKey = this.CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[townNameKey].Remove(person);

        // Remove by age
        this.personsByAge[person.Age].Remove(person);

        // Remove by town and age
        this.personsByTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var persons = this.personsByEmailDomain.GetValuesForKey(emailDomain);

        return persons;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameTownKey = this.CombineNameAndTown(name, town);
        var persons = this.personsByNameAndTown.GetValuesForKey(nameTownKey);

        return persons;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var persons = this.personsByAge.Range(startAge, true, endAge, true);

        foreach (var person in persons)
        {
            foreach (var p in person.Value)
            {
                yield return p;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            yield break;
        }

        var persons = this.personsByTownAndAge[town].Range(startAge, true, endAge, true);

        foreach (var person in persons)
        {
            foreach (var p in person.Value)
            {
                yield return p;
            }
        }

    }

    private string ExtractEmailDomain(string email)
    {
        return email.Split('@')[1];
    }

    private string CombineNameAndTown(string name, string town)
    {
        const string separator = "|!|";

        return name + separator + town;
    }
}
