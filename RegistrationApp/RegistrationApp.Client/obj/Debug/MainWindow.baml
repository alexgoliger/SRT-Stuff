   M S B A M L   `   `   `  ����Q  MRegistrationApp.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:RegistrationApp.ClientRegistrationApp.Client  5   	   '    !RegistrationApp.Client.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:RegistrationApp.Client     5   	     � Title$  Registration Application��5   	   $��550.905��6*   $��969.408��6;   .��5	      � .+�5
      �� -   5         ��Name$ Main_lbl��5
      $$��Welcome to Course Registration��6   $��53��6G   $��
183,10,0,0q�6S   $	��Top=�6g   $	��576��6   $
��Left=�6�   $��Center=�6�   $��32(�6�   �� 5      -   5        $ Student_Id_lbl��5      $��
Student ID��6$   $
��Left=�69   $��44��6T   $��	31,55,0,0q�6`   $	��Top=�6s   $	��121��6�   $��Center=�6�   $��21.333(�6�   �� 5      -   5         ��Name$ Student_Id_txt��5      $
��Left=�6&   $��23��6A   $��
40,104,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5      -   5        $ First_Name_lbl��5      $��
First Name��6$   $
��Left=�69   $��
38,150,0,0q�6T   $	��Top=�6h   $��40��6�   $	��112��6�   $��21.333(�6�   �� 5      -   5        $ First_Name_txt��5      $
��Left=�6&   $��23��6A   $��
40,195,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5      -   5        $ Last_Name_lbl��5      $��	Last Name��6#   $
��Left=�67   $��
40,249,0,0q�6R   $	��Top=�6f   $��40��6~   $	��110��6�   $��21.333(�6�   �� 5      -   5        $ Last_Name_txt��5      $
��Left=�6%   $��23��6@   $��
40,290,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5      -   5         ��Name$ Register_btn��5      $��Register��6#   $
��Left=�66   $��
40,348,0,0q�6Q   $	��Top=�6e   $	��110��6}   6�   �� 5      -	   5        $ Withdraw_btn��5      $��Withdraw��6#   $
��Left=�66   $��
40,373,0,0q�6Q   $	��Top=�6e   $	��110��6}   6�   �� 5      -
   5        $ View_Your_Courses_btn��5      $��View Your Courses��6,   $
��Left=�6H   $��
40,398,0,0q�6c   $	��Top=�6w   $	��110��6�   6�   �� 5      -   5        $ Change_Name_btn��5      $��Change Name��6&   $
��Left=�6<   $��
40,423,0,0q�6W   $	��Top=�6k   $	��110��6�   6�   �� 5      -   5        $ Courses_Available_lbl��5      $*��$The following courses are available:��6+   $
��Left=�6Z   $��
245,55,0,0q�6u   $	��Top=�6�   $��40��6�   $	��344��6�   $��21.333(�6�   �� 5      -   5        $ Current_Schedule_lbl��5      $��Your Current Schedule:��6*   $
��Left=�6K   $��
682,55,0,0q�6f   $	��Top=�6z   $��35��6�   $	��236��6�   $��21.333(�6�   $��Center=�6�   �� 5      -   5         ��Name$ Available_Courses_list��5      $
��Left=�6.   $	��406��6I   $��
245,98,0,0q�6V   $	��Top=�6j   $	��324��6�   �� 5      -   5        $ Current_Courses_list��5      $
��Left=�6,   $	��406��6G   $��
627,98,0,0q�6T   $	��Top=�6h   $	��324��6�   �� 5      -   5        $ Exit_btn��5      $
��Exit��6   $
��Left=�6.   $��
40,448,0,0q�6I   $	��Top=�6]   $	��110��6u   6�   5      5      