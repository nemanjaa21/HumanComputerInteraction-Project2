   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NetworkServiceNetworkService  5   	   ;"clr-namespace:NetworkService.ViewsNetworkService.Views  5   	   C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5   	       NetworkService.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NetworkService     5   	   4views"clr-namespace:NetworkService.Views     5   	   <	viewModel&clr-namespace:NetworkService.ViewModel     5   	     � Title$  CG5 T3 G2 P2��5
   	   $	��800��6   $
��1400��6+    � WindowState$ 	Maximized=�68    � WindowStartupLocation$ Manual=�6P    � DataContext 5      2   ,NetworkService.ViewModel.MainWindowViewModel  5   
    � 	Resources 5       �� DataType7   1NetworkService.ViewModel.NetworkEntitiesViewModel.   (NetworkService.Views.NetworkEntitiesView6   0NetworkService.ViewModel.NetworkDisplayViewModel-   'NetworkService.Views.NetworkDisplayView8   2NetworkService.ViewModel.MeasurementGraphViewModel/   )NetworkService.Views.MeasurementGraphView��%�   (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5       J� InputBindings 5      �� 5   
    �� 	Modifiers$
 Ctrlf�67   
 �� Key$	 Tab��6H   	 �� Command	 6   �� *ChangeCommand+6H   .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   �� 5       $
��Auto �6   .+�5"   
   ]� $��0��6   $��5q�6!   .+�5#      o� $	��Top=�6   .@�5$      m� $��Network Entities��6   $��5q�65   $��20(�6A   $��Comic Sans MS)�6O    m� CommandParameter$ NetEnt��5%   :    m� Command 6   �� *
NavCommand+6:   m� 5&      $��Network Display��6   $��5q�64   $��20(�6?   $��Comic Sans MS)�6M   $ NetDis��5'   :    6   �� *
NavCommand+6:   m� 5(      $��Measurement Graph��6   $��5q�66   $��20(�6A   $��Comic Sans MS)�6O   $ MesGraph��5)   :    6   �� *
NavCommand+6:   5*      5+      � 5-   
   $��1��6   .+�5.      �� ��6   �� *CurrentViewModel+5/      50      51      