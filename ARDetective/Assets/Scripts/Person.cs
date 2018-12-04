using UnityEngine;

public class Person {
	public string firstName;
	public string lastName;

	public Person(string fName, string lName) {
		firstName = fName;
		lastName = lName;
	}

	public string fullName  {
		get { return firstName + " " + lastName; }
	}

	public static bool operator ==(Person person, Person otherPerson)
	{
		return person.fullName == otherPerson.fullName;
	}

	public static bool operator !=(Person person, Person otherPerson)
	{
		return person.fullName != otherPerson.fullName;
	}

}
