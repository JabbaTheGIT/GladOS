package md5806cbdcde086e6612e76aee9f4ef127b;


public class EventView
	extends mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("GladOS.Droid.Views.EventView, GladOS.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EventView.class, __md_methods);
	}


	public EventView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EventView.class)
			mono.android.TypeManager.Activate ("GladOS.Droid.Views.EventView, GladOS.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}