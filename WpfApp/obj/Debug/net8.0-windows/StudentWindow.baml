   M S B A M L   `   `   `  ����
  WpfApp    WpfApp.StudentWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quản lý Học viên��5   	   $	��650��6"   $	��800��6/   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5         ��Name$ btnAdd��5      $��Thêm��6%   $	��100��64   $��0,0,10,0q�6@   6R   �� 5      -   5        $ btnEdit��5      $��Sửa��6&   $	��100��64   $��0,0,10,0q�6@   6R   �� 5      -   5        $ 	btnDelete��5      $
��Xóa��6(   $	��100��66   $��0,0,10,0q�6B   6T   �� 5      -   5        $ btnSave��5      $
��Lưu��6&   $	��100��64   $��0,0,10,0q�6@   6R   �� 5      -   5        $ 	btnCancel��5      $��Hủy��6(   $	��100��66   6B   5      �� 5   
   $��1��6   $��10q�6"   .@�5      �� $��Thông tin Học viên��6   .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+    5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5       $
��Auto �6(   �� 5!      $��* �6(   .+�5$      �� $��0��6   $��0��6)   $��Mã học viên:��69   �� 5%      -   5         ��Name$ txtStudentID��5%   ;   $��0��6   $��1��6+   $��0,0,0,5q�6Q   �� 5'      $��1��6   $��0��6)   $��Họ và tên:��69   �� 5(      -   5        $ txtFullName��5(   ;   $��1��6   $��1��6+   $��0,0,0,5q�6P   �� 5*      $��2��6   $��0��6)   $��Số điện thoại:��69   �� 5+      -   5        $ txtTelephone��5+   ;   $��2��6   $��1��6+   $��0,0,0,5q�6Q   �� 5-      $��3��6   $��0��6)   $��Email:��69   �� 5.      -	   5        $ txtEmail��5.   ;   $��3��6   $��1��6+   $��0,0,0,5q�6M   �� 50      $��4��6   $��0��6)   $��Ngày sinh:��69   (  "System.Windows.Controls.DatePicker  51      -
   5          Name$ 
dpBirthday��51   >   $��4��6!   $��1��6.   $��0,0,0,5q�6R   �� 53      $��5��6   $��0��6)   $��Trạng thái:��69   �� 54      -   5         ��Name$ 	cboStatus��54   <   $��5��6   $��1��6,   $��0,0,0,5q�6O   &   System.Windows.Controls.DataGrid  56      -   5          Name$ 
dgStudents��56   @   $��6��6   $��2��6,   	   AutoGenerateColumns$	 False��6T   $��0,10,0,0q�6p   
   Columns
 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã học viên��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *	StudentID+  59      $ Họ và tên��61    6D   �� *StudentFullName+  5:      $ Số điện thoại��61    6H   �� *	Telephone+  5;      $ Email��61    6@   �� *EmailAddress+  5<      $ 
Ngày sinh��61    6D   �� *StudentBirthday+ �� StringFormat$ d��  5=      $ Trạng thái��61    6E   �� *StudentStatus+5?      5@      5A      �� 5C      $��Khóa học��6   .��5D        -   5        $ 	dgCourses��5D      $	 False��6.   
 5E        5F      $ Mã khóa học��6-    6B   �� *
CourseID+  5G      $ Tên khóa học��6-    6C   �� *
CourseName+  5H      $ Loại khóa học��6-    6D   �� *
CourseType+  5I      $ Ngày bắt đầu��6-    6C   �� *	StartDate+$ d��  5J      $ Ngày kết thúc��6-    6D   �� *	EndDate+$ d��  5K      $ Trạng thái��6-    6A   �� *CourseStatus+5M      5N      �� 5P      $��
Lịch thi��6   .��5Q        -   5        $ dgExamSchedules��5Q      $	 False��64   
 5R        5S      $ Mã lịch thi��6-    6B   �� *ExamID+  5T      $ 	Ngày thi��6-    6?   �� *
ExamDate+$ d��  5U      $ 
Loại thi��6-    6?   �� *
ExamType+  5V      $ Trạng thái��6-    6A   �� *
ExamStatus+5X      5Y      �� 5[      $��Bằng lái��6   .��5\        -   5        $ 
dgLicenses��5\      $	 False��6/   
 5]        5^      $ Mã bằng lái��6-    6B   �� *	LicenseID+  5_      $ Loại bằng��6-    6@   �� *LicenseType+  5`      $ Ngày cấp��6-    6?   �� *	IssueDate+$ d��  5a      $ Ngày hết hạn��6-    6C   �� *
ExpiryDate+$ d��  5b      $ Trạng thái��6-    6A   �� *Status+5d      5e      5f      5g      5h      