//=====================================
// Project: Server_CellPhone
// Author: JJstorm
// Project Time: 54 mins
// Submitted: 7/19/2011
// Fixed by Lake (7/2016)
//=====================================

package CellPhone
{
	function serverCmdmessageSent(%client, %text)
	{
		// Call
		if(%client.call == 1)
		{
			%target = findclientbybl_id(%client.bl_idcalling);
			messageclient(%target, '', '\c3[\c2Call \c6- \c4%1\c3]: \c6%2', %client.name, %text);
			messageclient(%client, '', '\c3[\c2Call \c6- \c4%1\c3]: \c6%2', %client.name, %text);
			echo("[Call - " @ %jj @ %client.name @ "]: " @ %text);
			return;
		}
		else if(%client.emergency == 1)
		{
			if(%text >= 0 && %text < 5)
			{
				switch$(%text)
				{
					case 0:
						messageClient(%client,'', '\c6Your Call Has Been dismissed.');
						%client.emergency = 0;
					case 1:
						messageAll('', '\c3%1 \c6has reported a \c3murder/injury \c6at their location. (\c3%2\c6)', %client.name, %client.player.getTransform());
						%client.emergency = 0;
					case 2:
						messageClient(%client, '', '\c6Whats the name of the Abusive Admin? \c3Use regular chat to mention the name\c6.');
						%client.emergency = 2;
					case 3:
						for(%cl=0;%cl<ClientGroup.getCount();%cl++)
						{
							%target = ClientGroup.getObject(%cl);
							if(isObject(%target))
							{
								if(%target.isAdmin)
								{
									messageClient(%target, '', '\c3%1\c6, Reported a rule being broken at his/her location.');
								}
							}
						}
						%client.emergency = 0;
					case 4:
						messageAll('', '\c3%1\c6, has reported a emergency at his/her location (\c3%2\c6)', %client.name, %client.player.getTransform());
						%client.emergency = 0;
				}
				messageClient(%client, '', '\c3Call Ended');
			}
			else
			{
				messageClient(%client, '', '\c6Unknown Option.');
				%client.emergency = 0;
			}
			return;
		}
		else if(%client.emergency == 2)
		{
			%target = findclientbyname(%text);
			if(isObject(%target))
			{
				if(%target.isAdmin)
				{
					messageAll('', '\c6BEWARE OF \c3%1\c6. HE/SHE IS AN ABUSIVE ADMIN!', %target.name);
				}
				else
				{
					messageClient(%client, '', '\c3%1\c6 is not an admin.', %target.name);
				}
			}
			else
			{
				messageClient(%client, '', '\c6No client found with that name.');
			}
			%client.emergency = 0;
			return;
		}
		else
		{
			parent::serverCmdmessageSent(%client, %text);
		}
	}

	function gameConnection::autoAdminCheck(%client)
	{
		messageClient(%client, '', '\c6This server is running the cellphone mod \c3v%1 \c6use \c3/call \c6to use the phone.', $Pref::Server::CellPhoneVersion);
		return parent::autoAdminCheck(%client);
	}
};
activatepackage(CellPhone);