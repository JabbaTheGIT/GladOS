package md582645622390dd7fc8b52c1ee662b7717;


public class MyGcmListenerService
	extends com.google.android.gms.gcm.GcmListenerService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDeletedMessages:()V:GetOnDeletedMessagesHandler\n" +
			"n_onMessageReceived:(Ljava/lang/String;Landroid/os/Bundle;)V:GetOnMessageReceived_Ljava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_onMessageSent:(Ljava/lang/String;)V:GetOnMessageSent_Ljava_lang_String_Handler\n" +
			"n_onSendError:(Ljava/lang/String;Ljava/lang/String;)V:GetOnSendError_Ljava_lang_String_Ljava_lang_String_Handler\n" +
			"";
		mono.android.Runtime.register ("gladOS.Droid.Views.MyGcmListenerService, gladOS.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyGcmListenerService.class, __md_methods);
	}


	public MyGcmListenerService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyGcmListenerService.class)
			mono.android.TypeManager.Activate ("gladOS.Droid.Views.MyGcmListenerService, gladOS.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onDeletedMessages ()
	{
		n_onDeletedMessages ();
	}

	private native void n_onDeletedMessages ();


	public void onMessageReceived (java.lang.String p0, android.os.Bundle p1)
	{
		n_onMessageReceived (p0, p1);
	}

	private native void n_onMessageReceived (java.lang.String p0, android.os.Bundle p1);


	public void onMessageSent (java.lang.String p0)
	{
		n_onMessageSent (p0);
	}

	private native void n_onMessageSent (java.lang.String p0);


	public void onSendError (java.lang.String p0, java.lang.String p1)
	{
		n_onSendError (p0, p1);
	}

	private native void n_onSendError (java.lang.String p0, java.lang.String p1);

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
