    System.Diagnostics.Process.Start("ipconfig", "/release"); //For disabling internet
    System.Diagnostics.Process.Start("ipconfig", "/renew"); //For enabling internet
	
	
	# disable and enable network
	
	netsh interface show interface
	netsh interface set interface “Wi-Fi 12” disable
	netsh interface set interface “Wi-Fi 12” enable
	
	
	#vdv
	
	isTest=false&goformId=SET_DEVICE_MODE&debug_enable=1