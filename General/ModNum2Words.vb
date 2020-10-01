Module ModNum2Words
    'Coverting number to words
    Public Function Towords(ByVal TheValue As String, Optional ByVal HigherCurrency As String = "", Optional ByVal LowerCurrency As String = "") As String
        On Error GoTo handler
        If TheValue = "" Then
            Towords = ""
            Exit Function
        End If

        Dim ToNaira, ToKobo As String
        Dim TheAmt As String = Trim(TheValue)
        Dim a As Integer = InStr(1, TheValue, ".")
        Dim Naira, Kobo As Long
        If a = 0 Then
            Naira = Int(TheValue)
        ElseIf a = 1 Then
            Naira = 0
            Kobo = Int(Mid(TheValue, a + 1))
        Else
            Naira = Int(Mid(TheValue, 1, a - 1))
            Kobo = Int(Mid(TheValue, a + 1))
        End If
        ToNaira = Trim(ConvertToWord(Naira))
        If ToNaira Like "* and" Then
            ToNaira = Left(ToNaira, Len(ToNaira) - 4)
        End If
        ToKobo = Trim(ConvertToWord(Kobo))
        If ToKobo Like "* and" Then
            ToKobo = Left(ToKobo, Len(ToKobo) - 4)
        End If
        Towords = IIf(ToNaira <> "", ToNaira + " " + HigherCurrency, ToNaira) + IIf(ToKobo <> "", " " + ToKobo + " " + LowerCurrency, ToKobo)
        Exit Function
        Resume
handler:
        If Err.Number = 13 Then
            Resume Next
        Else
            MsgBox(Err.Description, vbInformation, "ValueConverter")

        End If

    End Function

    Private Function ConvertToWord(ByVal TheAmt As String) As String
        On Error GoTo handler
        TheAmt = Trim(TheAmt)
        Dim Naira As Double = Val(TheAmt)
        If Right(GetAmtWord(Naira), 4) = " and" Then
            ConvertToWord = Mid(GetAmtWord(Naira), 1, Len(GetAmtWord(Naira)) - 4) '& " Naira Only"
        Else
            ConvertToWord = GetAmtWord(Naira) '& " Naira Only"
        End If

        Dim j As Integer = 1
        Dim a As Integer
        Dim LeftStr, LeftStr1, RightStr, RightStr1 As String
        Do
            a = InStr(j, ConvertToWord, " and ")
            If a > 0 Then

                LeftStr = Mid(ConvertToWord, 1, a - 1)
                LeftStr1 = Trim(Right(LeftStr, IIf(InStr(1, LeftStr, " ") > 0, 8, 0)))
                RightStr = Mid(ConvertToWord, a + 5)
                RightStr1 = Left(Trim(RightStr), 8)
                If (LCase(LeftStr1) = "hundred" Or LCase(LeftStr1) = "thousand" Or LCase(LeftStr1) = "million" Or LCase(LeftStr1) = "billion" Or LCase(LeftStr1) = "trillion") And (LCase(RightStr1) = "hundred" Or LCase(RightStr1) = "thousand" Or LCase(RightStr1) = "million" Or LCase(RightStr1) = "billion" Or LCase(RightStr1) = "trillion") Then
                    ConvertToWord = Mid(ConvertToWord, 1, a - 1) + Mid(ConvertToWord, a + 4)
                End If
                j = a + 5
            End If
        Loop Until a <= 0
        Exit Function
handler:
        MsgBox(Err.Description, vbInformation, "ValueConverter")
    End Function

    Private Function GetAmtWord(ByVal TheAmt) As String
        On Error GoTo handler
        TheAmt = Val(TheAmt)
        GetAmtWord = ""
        Dim TheLen As Integer = Len(Trim(TheAmt))
        Dim i As Integer
        Select Case TheLen
            Case Is <= 2 And TheAmt <> 0
                If GetWord4Value(TheAmt) = "" Then
                    For i = 20 To 90 Step 10
                        If i > TheAmt Then Exit For
                    Next i
                    GetAmtWord = GetWord4Value(i - 10) & " " & GetWord4Value(TheAmt - (i - 10))
                Else
                    GetAmtWord = GetWord4Value(TheAmt)
                End If
            Case Is = 3
                If Right(GetWord4Value(Mid(TheAmt, 1, 1)), 4) = " and" Then
                    GetAmtWord = Mid(GetWord4Value(Mid(TheAmt, 1, 1)), 1, Len(GetWord4Value(Mid(TheAmt, 1, 1))) - 4) & " Hundred and " & GetAmtWord(Mid(TheAmt, 2))
                Else
                    GetAmtWord = GetWord4Value(Mid(TheAmt, 1, 1)) & " Hundred and " & GetAmtWord(Mid(TheAmt, 2))
                End If
            Case Is = 4
                If Right(GetWord4Value(Mid(TheAmt, 1, 1)), 4) = " and" Then
                    GetAmtWord = Mid(GetWord4Value(Mid(TheAmt, 1, 1)), 1, Len(GetAmtWord(Mid(TheAmt, 1, 1))) - 4) & " Thousand " & GetAmtWord(Mid(TheAmt, 2))
                Else
                    GetAmtWord = GetWord4Value(Mid(TheAmt, 1, 1)) & " Thousand " & GetAmtWord(Mid(TheAmt, 2))
                End If
            Case Is = 5
                If Right(GetAmtWord(Mid(TheAmt, 1, 2)), 4) = " and" Then
                    GetAmtWord = Mid(GetAmtWord(Mid(TheAmt, 1, 2)), 1, Len(GetAmtWord(Mid(TheAmt, 1, 2))) - 4) & " Thousand " & GetAmtWord(Mid(TheAmt, 3))
                Else
                    GetAmtWord = GetAmtWord(Mid(TheAmt, 1, 2)) & " Thousand " & GetAmtWord(Mid(TheAmt, 3))
                End If
            Case Is = 6
                If Right(GetAmtWord(Mid(TheAmt, 1, 3)), 4) = " and" Then
                    GetAmtWord = Mid(GetAmtWord(Mid(TheAmt, 1, 3)), 1, Len(GetAmtWord(Mid(TheAmt, 1, 3))) - 4) & "Thousand " & GetAmtWord(Mid(TheAmt, 4))
                Else
                    GetAmtWord = GetAmtWord(Mid(TheAmt, 1, 3)) & " Thousand " & GetAmtWord(Mid(TheAmt, 4))
                End If
            Case Is = 7
                GetAmtWord = GetWord4Value(Mid(TheAmt, 1, 1)) & " Million " & GetAmtWord(Mid(TheAmt, 2))
            Case Is = 8
                GetAmtWord = GetAmtWord(Mid(TheAmt, 1, 2)) & " Million " & GetAmtWord(Mid(TheAmt, 3))
            Case Is = 9
                GetAmtWord = GetAmtWord(Mid(TheAmt, 1, 3)) & " Million " & GetAmtWord(Mid(TheAmt, 4))
            Case Is = 10
                GetAmtWord = GetWord4Value(Mid(TheAmt, 1, 1)) & " Billion " & GetAmtWord(Mid(TheAmt, 2))
            Case Is = 11
                GetAmtWord = GetAmtWord(Mid(TheAmt, 1, 2)) & " Billion " & GetAmtWord(Mid(TheAmt, 3))
            Case Is = 12
                GetAmtWord = GetAmtWord(Mid(TheAmt, 1, 3)) & " Billion " & GetAmtWord(Mid(TheAmt, 4))
        End Select
        Exit Function
handler:
        MsgBox(Err.Description, vbInformation, "ValueConverter")

    End Function

    Private Function GetWord4Value(ByVal TheValue, Optional ByVal TheAmt = 0) As String
        On Error GoTo handler
        GetWord4Value = ""
        TheValue = Val(TheValue)
        If TheValue = 1 Then GetWord4Value = "One"
        If TheValue = 2 Then GetWord4Value = "Two"
        If TheValue = 3 Then GetWord4Value = "Three"
        If TheValue = 4 Then GetWord4Value = "Four"
        If TheValue = 5 Then GetWord4Value = "Five"
        If TheValue = 6 Then GetWord4Value = "Six"
        If TheValue = 7 Then GetWord4Value = "Seven"
        If TheValue = 8 Then GetWord4Value = "Eight"
        If TheValue = 9 Then GetWord4Value = "Nine"
        If TheValue = 10 Then GetWord4Value = "Ten"
        If TheValue = 11 Then GetWord4Value = "Eleven"
        If TheValue = 12 Then GetWord4Value = "Twelve"
        If TheValue = 13 Then GetWord4Value = "Thirteen"
        If TheValue = 14 Then GetWord4Value = "Fourteen"
        If TheValue = 15 Then GetWord4Value = "Fifteen"
        If TheValue = 16 Then GetWord4Value = "Sixteen"
        If TheValue = 17 Then GetWord4Value = "Seventeen"
        If TheValue = 18 Then GetWord4Value = "Eighteen"
        If TheValue = 19 Then GetWord4Value = "Nineteen"
        If TheValue = 20 Then GetWord4Value = "Twenty"
        If TheValue = 30 Then GetWord4Value = "Thirty"
        If TheValue = 40 Then GetWord4Value = "Fourty"
        If TheValue = 50 Then GetWord4Value = "Fifty"
        If TheValue = 60 Then GetWord4Value = "Sixty"
        If TheValue = 70 Then GetWord4Value = "Seventy"
        If TheValue = 80 Then GetWord4Value = "Eighty"
        If TheValue = 90 Then GetWord4Value = "Ninety"
        Exit Function
handler:
        MsgBox(Err.Description, vbInformation, "ValueConverter")

    End Function


End Module
