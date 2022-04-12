using System;
public abstract class StorageResuorses
{
    public virtual void GetResourses(BlackItem black)
    {
        throw new NotImplementedException();
    }
    public virtual void GetResourses(BlackItem black, RedItem red)
    {
        throw new NotImplementedException();
    }
    public virtual bool GiveResourses(IItem item)
    {
        throw new NotImplementedException();
    }   
}





