' Define a CommException class that inherits from the ApplicationException class, 
' and then throw an object of type CommException when you receive an error message.
Imports System.Text
Class CommException
    Inherits ApplicationException
    Sub New(ByVal Reason As String)
        MyBase.New(Reason)
    End Sub
End Class

Module AccessingPortsModule
    Public Structure DCB
        Public DCBlength As Int32
        Public BaudRate As Int32
        Public fBitFields As Int32
        Public wReserved As Int16
        Public XonLim As Int16
        Public XoffLim As Int16
        Public ByteSize As Byte
        Public Parity As Byte
        Public StopBits As Byte
        Public XonChar As Byte
        Public XoffChar As Byte
        Public ErrorChar As Byte
        Public EofChar As Byte
        Public EvtChar As Byte
        Public wReserved1 As Int16 'Reserved; Do Not Use
    End Structure

    Public Structure COMMTIMEOUTS
        Public ReadIntervalTimeout As Int32
        Public ReadTotalTimeoutMultiplier As Int32
        Public ReadTotalTimeoutConstant As Int32
        Public WriteTotalTimeoutMultiplier As Int32
        Public WriteTotalTimeoutConstant As Int32
    End Structure

    Public Const GENERIC_READ As Int32 = &H80000000
    Public Const GENERIC_WRITE As Int32 = &H40000000
    Public Const OPEN_EXISTING As Int32 = 3
    Public Const FILE_ATTRIBUTE_NORMAL As Int32 = &H80
    Public Const NOPARITY As Int32 = 0
    Public Const ONESTOPBIT As Int32 = 0

    Public Declare Auto Function CreateFile Lib "kernel32.dll" _
       (ByVal lpFileName As String, ByVal dwDesiredAccess As Int32, _
          ByVal dwShareMode As Int32, ByVal lpSecurityAttributes As IntPtr, _
             ByVal dwCreationDisposition As Int32, ByVal dwFlagsAndAttributes As Int32, _
                ByVal hTemplateFile As IntPtr) As IntPtr

    'Public Declare Auto Function GetCommState Lib "kernel32.dll" (ByVal nCid As IntPtr, _
    '   ByRef lpDCB As DCB) As Boolean

    'Public Declare Auto Function SetCommState Lib "kernel32.dll" (ByVal nCid As IntPtr, _
    '   ByRef lpDCB As DCB) As Boolean

    'Public Declare Auto Function GetCommTimeouts Lib "kernel32.dll" (ByVal hFile As IntPtr, _
    '   ByRef lpCommTimeouts As COMMTIMEOUTS) As Boolean

    'Public Declare Auto Function SetCommTimeouts Lib "kernel32.dll" (ByVal hFile As IntPtr, _
    '   ByRef lpCommTimeouts As COMMTIMEOUTS) As Boolean

    Public Declare Auto Function WriteFile Lib "kernel32.dll" (ByVal hFile As IntPtr, _
       ByVal lpBuffer As Byte(), ByVal nNumberOfBytesToWrite As Int32, _
          ByRef lpNumberOfBytesWritten As Int32, ByVal lpOverlapped As IntPtr) As Boolean

    'Public Declare Auto Function ReadFile Lib "kernel32.dll" (ByVal hFile As IntPtr, _
    '   ByVal lpBuffer As Byte(), ByVal nNumberOfBytesToRead As Int32, _
    '      ByRef lpNumberOfBytesRead As Int32, ByVal lpOverlapped As IntPtr) As Boolean

    Public Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean
    Public Sub AccessPort(ByVal PortName As String, ByVal tData As String)
        'On Error Resume Next
        On Error GoTo handler

        Dim hSerialPort, hParallelPort As IntPtr
        Dim Success As Boolean
        'Dim MyDCB As DCB
        'Dim MyCommTimeouts As COMMTIMEOUTS
        Dim BytesWritten As Int32
        'Dim BytesRead As Int32
        Dim Buffer() As Byte
        If tData Is Nothing Then Exit Sub
        ' Convert String to Byte().
        Buffer = Encoding.Default.GetBytes(tData)

        'AccessPort(cPole.Text, "")
        'tData = "Your Charge is" + Chr(10) + Chr(13) + tData
        ' AccessPort(cPole.Text, tPayable.Text + " Naira")

        If InStr(PortName, "COM") > 0 Then
            ' Try
            '' Serial port.
            'Console.WriteLine("Accessing the COM1 serial port")
            '' Obtain a handle to the COM1 serial port.


            hSerialPort = CreateFile(PortName, GENERIC_READ Or GENERIC_WRITE, 0, IntPtr.Zero, _
                  OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero)
            '' Verify that the obtained handle is valid.
            'If hSerialPort.ToInt32 = -1 Then
            '    Throw New CommException("Unable to obtain a handle to the COM1 port")
            'End If
            '' Retrieve the current control settings.
            'Success = GetCommState(hSerialPort, MyDCB)
            'If Success = False Then
            '    Throw New CommException("Unable to retrieve the current control settings")
            'End If
            '' Modify the properties of MyDCB as appropriate.
            '' WARNING: Make sure to modify the properties in accordance with their supported values.
            'MyDCB.BaudRate = 9600
            'MyDCB.ByteSize = 8
            'MyDCB.Parity = NOPARITY
            'MyDCB.StopBits = ONESTOPBIT
            
            '' Reconfigure COM1 based on the properties of MyDCB.
            'Success = SetCommState(hSerialPort, MyDCB)
            'If Success = False Then
            '    Throw New CommException("Unable to reconfigure COM1")
            'End If
            '' Retrieve the current time-out settings.
            'Success = GetCommTimeouts(hSerialPort, MyCommTimeouts)
            'If Success = False Then
            '    Throw New CommException("Unable to retrieve current time-out settings")
            'End If
            '' Modify the properties of MyCommTimeouts as appropriate.
            '' WARNING: Make sure to modify the properties in accordance with their supported values.
            'MyCommTimeouts.ReadIntervalTimeout = 0
            'MyCommTimeouts.ReadTotalTimeoutConstant = 0
            'MyCommTimeouts.ReadTotalTimeoutMultiplier = 0
            'MyCommTimeouts.WriteTotalTimeoutConstant = 0
            'MyCommTimeouts.WriteTotalTimeoutMultiplier = 0
            '' Reconfigure the time-out settings, based on the properties of MyCommTimeouts.
            'Success = SetCommTimeouts(hSerialPort, MyCommTimeouts)
            'If Success = False Then
            '    Throw New CommException("Unable to reconfigure the time-out settings")
            'End If
            '' Write data to COM1.
            'Console.WriteLine("Writing the following data to COM1: Test")
            Success = WriteFile(hSerialPort, Buffer, Buffer.Length, BytesWritten, IntPtr.Zero)
            System.Threading.Thread.Sleep(5)
            Application.DoEvents()
            'If Success = False Then
            '    Throw New CommException("Unable to write to COM1")
            'End If
            '' Read data from COM1.
            'Success = ReadFile(hSerialPort, Buffer, BytesWritten, BytesRead, IntPtr.Zero)
            'If Success = False Then
            '    Throw New CommException("Unable to read from COM1")
            'End If
            'Catch ex As Exception
            '    Console.WriteLine(Ex.Message)
            'Finally
            '    ' Release the handle to COM1.
            Success = CloseHandle(hSerialPort)
            'If Success = False Then
            '    Console.WriteLine("Unable to release handle to COM1")
            'End If
            'End Try
        Else
            'Try
            '    ' Parallel port.
            '    Console.WriteLine("Accessing the LPT1 parallel port")
            ' Obtain a handle to the LPT1 parallel port.
            hParallelPort = CreateFile(PortName, GENERIC_READ Or GENERIC_WRITE, 0, IntPtr.Zero, _
               OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero)
            '' Verify that the obtained handle is valid.
            'If hParallelPort.ToInt32 = -1 Then
            '    Throw New CommException("Unable to obtain a handle to the LPT1 port")
            'End If
            '' Retrieve the current control settings.
            'Success = GetCommState(hParallelPort, MyDCB)
            'If Success = False Then
            '    Throw New CommException("Unable to retrieve the current control settings")
            'End If
            '' Modify the properties of MyDCB as appropriate.
            '' WARNING: Make sure to modify the properties in accordance with their supported values.
            'MyDCB.BaudRate = 9600
            'MyDCB.ByteSize = 8
            'MyDCB.Parity = NOPARITY
            'MyDCB.StopBits = ONESTOPBIT
            '' Reconfigure LPT1 based on the properties of MyDCB.
            'Success = SetCommState(hParallelPort, MyDCB)
            'If Success = False Then
            '    Throw New CommException("Unable to reconfigure LPT1")
            'End If
            '' Retrieve the current time-out settings.
            'Success = GetCommTimeouts(hParallelPort, MyCommTimeouts)
            'If Success = False Then
            '    Throw New CommException("Unable to retrieve current time-out settings")
            'End If
            '' Modify the properties of MyCommTimeouts as appropriate.
            '' WARNING: Make sure to modify the properties in accordance with their supported values.
            'MyCommTimeouts.ReadIntervalTimeout = 0
            'MyCommTimeouts.ReadTotalTimeoutConstant = 0
            'MyCommTimeouts.ReadTotalTimeoutMultiplier = 0
            'MyCommTimeouts.WriteTotalTimeoutConstant = 0
            'MyCommTimeouts.WriteTotalTimeoutMultiplier = 0
            '' Reconfigure the time-out settings, based on the properties of MyCommTimeouts.
            'Success = SetCommTimeouts(hParallelPort, MyCommTimeouts)
            'If Success = False Then
            '    Throw New CommException("Unable to reconfigure the time-out settings")
            'End If
            '' Write data to LPT1.
            'Console.WriteLine("Writing the following data to LPT1: Test")
            Success = WriteFile(hParallelPort, Buffer, Buffer.Length, BytesWritten, IntPtr.Zero)
            System.Threading.Thread.Sleep(5)
            Application.DoEvents()
            'If Success = False Then
            '    Throw New CommException("Unable to write to LPT1")
            'End If
            'Catch ex As Exception
            '    Console.WriteLine(ex.Message)
            'Finally
            '    ' Release the handle to LPT1.
            Success = CloseHandle(hParallelPort)
            'If Success = False Then
            '    Console.WriteLine("Unable to release handle to LPT1")
            'End If
            'End Try
        End If

        Exit Sub

        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

End Module
