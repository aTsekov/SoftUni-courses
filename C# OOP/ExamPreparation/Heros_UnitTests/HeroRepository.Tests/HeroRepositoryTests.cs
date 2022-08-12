using System;
using System.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void TestCtorOfHeroClass()
    {
        var hero = new Hero("Gosho", 20);

        string expectedName = "Gosho";
        string actualName = hero.Name;
        int expectedLevel = 20;
        int actualLevel = hero.Level;
        Assert.AreEqual(expectedName, actualName);
        Assert.AreEqual(expectedLevel, actualLevel);
    }
    [Test]
    public void TestHeroRepositoryCreateHeroCannotBeNull()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("", 20);
        hero = null;

        Assert.Throws<ArgumentNullException>(() =>
       {
           heroRepo.Create(hero);
       }, "Hero is null");
    }
    [Test]
    public void TestHeroCannotBedubplicated()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Gosho", 20);
        heroRepo.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            var hero1 = new Hero("Gosho", 22);
            heroRepo.Create(hero1);
        }, $"Hero with name {hero.Name} already exists");
    }
    [Test]
    public void TestIfCreateReturnsCorrectMessageWhenHeroWasAdded()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Gosho", 20);


        Assert.Pass((heroRepo.Create(hero)), $"Successfully added hero {hero.Name} with level {hero.Level}");
    }
    [Test]
    public void TestCreatesANewHeroAndAddsItToTheCollection()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Gosho", 20);
        heroRepo.Create(hero);
        heroRepo.Heroes.Any(h => h.Name == hero.Name);
        Assert.That(heroRepo.Heroes.Any(h => h.Name == hero.Name));
    }
    [TestCase("")]
    [TestCase("  ")]
    [TestCase(null)]
    public void RemoveParamCannotBeNullOrWhiteSpace(string name)
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Gosho", 20);
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepo.Remove(name);
        }, $"Name cannot be null");
    }
    [Test]
    public void TestIfRemovedSucsefully()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Gosho", 20);
        heroRepo.Create(hero);
        bool expected = heroRepo.Remove("Gosho");
        bool actual = true;


        Assert.AreEqual(expected, actual);
    }
    [Test]
    public void TestGetHeroWithHighestLevel()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Gosho", 20);
        var hero2 = new Hero("Posho", 300);
        var hero3 = new Hero("Mosho", 400);
        heroRepo.Create(hero);
        heroRepo.Create(hero2);
        heroRepo.Create(hero3);

        var expectedLevel = hero3;
        var ActualLevel = heroRepo.GetHeroWithHighestLevel();
        Assert.AreEqual(expectedLevel, ActualLevel);
    }
    [Test]

    public void TestGetHero()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Gosho", 20);
        var hero2 = new Hero("Posho", 300);
        var hero3 = new Hero("Mosho", 400);
        heroRepo.Create(hero);
        heroRepo.Create(hero2);
        heroRepo.Create(hero3);

        var expectedHero = hero3;
        var ActualHero = heroRepo.GetHero("Mosho");
        Assert.AreEqual(expectedHero, ActualHero);
    }
    [Test]
    public void TestHerosCount()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Gosho", 20);
        var hero2 = new Hero("Posho", 300);
        var hero3 = new Hero("Mosho", 400);
        heroRepo.Create(hero);
        heroRepo.Create(hero2);
        heroRepo.Create(hero3);
        var expectedCount = 3; 
        var actualvount = heroRepo.Heroes.Count();

       Assert.AreEqual(expectedCount, actualvount);

    }

}
