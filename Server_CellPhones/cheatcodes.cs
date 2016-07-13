function cheat(%client, %code)
{
	if(%client.hasSpawnedOnce)
	{
		if(%code !$= "")
		{
			if(!%client.isCheater)
			{
				switch$(%code)
				{
					// Replenish Health (Can Only Be Used Once)
					case 911:
						%addhealth = %client.player.dataBlock.maxDamage;
						%client.player.setHealth(%addhealth);
						messageclient(%client, '', '\c6You have regained \c3100% \c6of your health. Cheats Are Now \c0Disabled\c6.');
						%client.isCheater = 1;
					
					case test:
						messageclient(%client, '', '\c6This is the test cheat it does nothing but show an example');
					
					// ========================================================================================================					
					// To add custom cheats look below (Advanced Users Only):
					//
					// VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV
					//
					// case CodeHere:
					// 		What to do when the code is used here.
					//
					// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
					// If you want the code to stop users from using anymore cheats put "%client.isCheater = 1;" in the cheat.
					// 
					// Still confused? Look at the above cheats to see what to do.
					//
					// Add cheats below this line
					// ========================================================================================================
				}
				return;
			}
			else
			{
				messageclient(%client, '', '\c6You are a cheater, you get nothing!');
				return;
			}
		}
		else
		{
			messageclient(%client, '', '\c6Enter a cheat code');
			return;
		}
	}
	else
	{
		messageclient(%client, '', '\c6You must spawn before using a cheat');
		return;	
	}
}