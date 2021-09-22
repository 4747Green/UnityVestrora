using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

public class StatusFactoryTester
{
    // A Test behaves as an ordinary method
    [Test]
    public void StatusFactoryTesterSimplePasses()
    {
        // Use the Assert class to test conditions
    }
    [Test]
    public void CreateObject()
    {
        Tester tester = new Tester("sss");
        Status Charmed = StatusFactory.CreateStatus(StatusFactory.StatusType.Charmed);
        Assert.IsNotNull(Charmed);

    }

    [Test]
    public void CreateObjectStatus()
    {

        Status Charmed = new Status(1, 2,StatusFactory.StatusType.Blinded);
        Assert.IsNotNull(Charmed);

    }

    [Test]
    public void CreateStatusFromFactory()
    {
        //Assert.Equals should not be used for Assertions
        Status sfBlinded = StatusFactory.CreateStatus(StatusFactory.StatusType.Blinded);
        Assert.IsNotNull(sfBlinded);
    }
    [Test]

    public void CheckIfTwoStatusesAreEqual()
    {

        Status sfBlinded = StatusFactory.CreateStatus(StatusFactory.StatusType.Blinded);
        Status sfBlinded2 = StatusFactory.CreateStatus(StatusFactory.StatusType.Blinded);
        Status blinded = new Status(1, 2,StatusFactory.StatusType.Blinded);
        if(blinded.stack == sfBlinded.stack){
             Assert.Pass();
        }else{
               Assert.Fail();
        }
        
    }
    [Test]
    public void CheckIfTwoStatusesAreEqual2()
    {

        Status sfBlinded = StatusFactory.CreateStatus(StatusFactory.StatusType.Blinded);
        Status sfBlinded2 = StatusFactory.CreateStatus(StatusFactory.StatusType.Blinded);

        Assert.AreSame(sfBlinded, sfBlinded2);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator StatusFactoryTesterWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

}