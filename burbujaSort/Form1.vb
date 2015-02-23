Public Class Form1
    Dim arr(1) As Integer
    Dim arrCopy(1) As Integer
    Dim Index(1) As Integer
    Dim arrTemp() As Integer ' lo ocupa radix sort nada mas

    Dim mostrar As Integer
    Const maximoAmostrar = 500

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar = 500
        Label1.Text = "Elementos: " + (arr.Length - 1).ToString + "  Tiempo de ejecucion: "
    End Sub


    Sub Main()



 
        'sort the array using bubble sort

        bubbleSort(arr, arr.Length)

        'output the sorted array

        Dim i As Integer

        For i = 0 To arr.Length - 1

            Console.WriteLine(arr(i))

        Next

        Console.ReadLine() 'wait for keypress

        MsgBox("hola")
    End Sub



    Sub bubbleSort(ByVal dataset() As Integer, ByVal n As Integer)

        Dim i, j As Integer

        For i = 0 To n Step 1

            For j = n - 1 To i + 1 Step -1

                If (dataset(j) < dataset(j - 1)) Then


                    Dim temp As Integer = dataset(j)

                    dataset(j) = dataset(j - 1)

                    dataset(j - 1) = temp


                End If

            Next

        Next

    End Sub

    Private Sub MergeSort(ByVal ar() As Integer, ByVal low As Integer, ByVal high As Integer)

        If low >= high Then Return
        Dim length As Integer = high - low + 1
        Dim middle As Integer = Math.Floor((low + high) / 2)
        MergeSort(ar, low, middle)
        MergeSort(ar, middle + 1, high)
        Dim temp(ar.Length - 1) As Integer
        For i As Integer = 0 To length - 1
            temp(i) = ar(low + i)
        Next
        Dim m1 As Integer = 0
        Dim m2 As Integer = middle - low + 1
        For i As Integer = 0 To length - 1
            If m2 <= high - low Then
                If m1 <= middle - low Then
                    If temp(m1) > temp(m2) Then
                        ar(i + low) = temp(m2)
                        m2 += 1
                    Else
                        ar(i + low) = temp(m1)
                        m1 += 1
                    End If
                Else
                    ar(i + low) = temp(m2)
                    m2 += 1
                End If
            Else
                ar(i + low) = temp(m1)
                m1 += 1
            End If
        Next

    End Sub
    Private Sub btnLlenar_Click(sender As Object, e As EventArgs) Handles btnLlenar.Click
        'arr = {30, 12, 32, 34, 45, 90}

        If ComboBox2.SelectedItem = "" Then

            Exit Sub

        End If
        btnOrdenar.Enabled = True

        Dim tamarray As Integer
        tamarray = CInt(ComboBox2.Text)
        mostrar = maximoAmostrar
        If mostrar > tamarray Then
            mostrar = tamarray - 1
        End If
        ReDim arr(tamarray)
        ReDim arrCopy(tamarray)
        ReDim Index(tamarray)
        ReDim arrTemp(tamarray)
        TextBox1.Text = ""
        TextBox2.Text = ""
        txtSalida.Text = ""
        txtTodo.Text = ""
        Label1.Text = "Elementos: " + (arr.Length - 1).ToString
        For i = 0 To arr.Length - 1
            arr(i) = Int(Rnd() * 1000) + 1
            arrCopy(i) = arr(i)
        Next
        For i = 0 To mostrar 'solo muestra los primeros 100 en el textbox
            TextBox1.Text = TextBox1.Text + " " + arr(i).ToString
        Next
    End Sub
    Private Sub vuelveLlenar()
        For i = 0 To arr.Length - 1
            arr(i) = arrCopy(i)
        Next
    End Sub
    Private Sub btnOrdenar_Click(sender As Object, e As EventArgs) Handles btnOrdenar.Click
        Dim date1 = DateTime.Now
        Dim resultado = date1 - date1
        txtTodo.Text = ""
        TextBox2.Text = ""
        If ComboBox1.SelectedItem = "" Then
            MsgBox("Elija un metodo de ordenamiento")
            ComboBox1.Focus()
            Exit Sub
        End If
        If ComboBox2.SelectedItem = "" Then
            MsgBox("Elija el tamaño del arreglo")
            ComboBox1.Focus()
            Exit Sub
        End If
        For x = 1 To NumericUpDown.Value
            vuelveLlenar()
            TextBox2.Text = ""
            date1 = DateTime.Now
            If ComboBox1.SelectedItem = "Burbuja" Then
                bubbleSort(arr, arr.Length)
                Dim date2 = DateTime.Now
                resultado = date2 - date1
                Label1.Text = "Elementos: " + (arr.Length - 1).ToString
                txtSalida.Text = resultado.ToString
                txtTodo.Text = txtTodo.Text + resultado.ToString + vbNewLine
                For i = 0 To mostrar 'solo muestra los primeros 100 en el textbox
                    TextBox2.Text = TextBox2.Text + " " + arr(i).ToString
                Next
            End If
            If ComboBox1.SelectedItem = "Quicksort" Then
                'QuickSort(arr, 0, arr.Length - 1)
                QuickSort2(arr)
                Dim date2 = DateTime.Now
                resultado = date2 - date1
                Label1.Text = "Elementos: " + (arr.Length - 1).ToString
                txtSalida.Text = resultado.ToString
                txtTodo.Text = txtTodo.Text + resultado.ToString + vbNewLine
                For i = 0 To mostrar 'solo muestra los primeros 100 en el textbox
                    TextBox2.Text = TextBox2.Text + " " + arr(i).ToString
                Next
            End If

            If ComboBox1.SelectedItem = "MergeSort" Then
                MergeSort(arr, 0, arr.Length - 1)
                Dim date2 = DateTime.Now
                resultado = date2 - date1
                Label1.Text = "Elementos: " + (arr.Length - 1).ToString
                txtSalida.Text = resultado.ToString
                txtTodo.Text = txtTodo.Text + resultado.ToString + vbNewLine
                For i = 0 To mostrar 'solo muestra los primeros 100 en el textbox
                    TextBox2.Text = TextBox2.Text + " " + arr(i).ToString
                Next
            End If
            If ComboBox1.SelectedItem = "InsertionSort" Then
                'InsertionSort(arr, arr.Length - 1)
                InsertionSort2(arr)
                Dim date2 = DateTime.Now
                resultado = date2 - date1
                Label1.Text = "Elementos: " + (arr.Length - 1).ToString
                txtSalida.Text = resultado.ToString
                txtTodo.Text = txtTodo.Text + resultado.ToString + vbNewLine
                For i = 0 To mostrar 'solo muestra los primeros 100 en el textbox
                    TextBox2.Text = TextBox2.Text + " " + arr(i).ToString
                Next
            End If
            If ComboBox1.SelectedItem = "selectionSort" Then
                selectionSort(arr, arr.Length - 1)
                Dim date2 = DateTime.Now
                resultado = date2 - date1
                Label1.Text = "Elementos: " + (arr.Length - 1).ToString
                txtSalida.Text = resultado.ToString
                txtTodo.Text = txtTodo.Text + resultado.ToString + vbNewLine
                For i = 0 To mostrar 'solo muestra los primeros 100 en el textbox
                    TextBox2.Text = TextBox2.Text + " " + arr(i).ToString
                Next
            End If
            If ComboBox1.SelectedItem = "HeapSort" Then
                HeapSort(arr)
                Dim date2 = DateTime.Now
                resultado = date2 - date1
                Label1.Text = "Elementos: " + (arr.Length - 1).ToString
                txtSalida.Text = resultado.ToString
                txtTodo.Text = txtTodo.Text + resultado.ToString + vbNewLine
                For i = 0 To mostrar 'solo muestra los primeros 100 en el textbox
                    TextBox2.Text = TextBox2.Text + " " + arr(i).ToString
                Next
            End If
            If ComboBox1.SelectedItem = "RadixSort" Then
                RadixSort(arr)
                Dim date2 = DateTime.Now
                resultado = date2 - date1
                Label1.Text = "Elementos: " + (arr.Length - 1).ToString
                txtSalida.Text = resultado.ToString
                txtTodo.Text = txtTodo.Text + resultado.ToString + vbNewLine
                For i = 0 To mostrar 'solo muestra los primeros 100 en el textbox
                    TextBox2.Text = TextBox2.Text + " " + arr(i).ToString
                Next
            End If

        Next




        If CheckBox.Checked Then My.Computer.Audio.Play("c:\Windows\Media\ring10.wav")

    End Sub

    Sub selectionSort(ByVal dataset() As Integer, ByVal n As Integer)

        Dim i, j As Integer
        Dim min As Integer
        For i = 0 To n - 1 Step 1

            For j = i + 1 To n - 1


                min = i
                If (dataset(j) < dataset(min)) Then

                    min = j 'find min value
                End If
            Next
            'then swap it with the item at the beginning of unsorted list
            Dim temp As Integer = dataset(i)

            dataset(i) = dataset(min)

            dataset(min) = temp
        Next

    End Sub
    Sub insertionSort(ByVal dataset() As Integer, ByVal n As Integer)

        Dim i, j As Integer

        For i = 1 To n - 1 Step 1

            Dim pick_item As Integer = dataset(i)
            Dim inserted As Integer = 0
            j = i - 1
            While (j >= 0 And inserted <> 1)

                If (pick_item < dataset(j)) Then
                    dataset(j + 1) = dataset(j)
                    j -= 1
                    dataset(j + 1) = pick_item
                Else : inserted = 1
                End If

            End While
        Next
    End Sub

    Public Sub InsertionSort2(ByRef lngArray() As Integer)
        Dim iOuter As Long
        Dim iInner As Long
        Dim iLBound As Long
        Dim iUBound As Long
        Dim iTemp As Long

        iLBound = LBound(lngArray)
        iUBound = UBound(lngArray)

        For iOuter = iLBound + 1 To iUBound

            'Get the value to be inserted
            iTemp = lngArray(iOuter)

            'Move along the already sorted values shifting along
            For iInner = iOuter - 1 To iLBound Step -1
                'No more shifting needed, we found the right spot!
                If lngArray(iInner) <= iTemp Then Exit For

                lngArray(iInner + 1) = lngArray(iInner)
            Next iInner

            'Insert value in the slot
            lngArray(iInner + 1) = iTemp
        Next iOuter
    End Sub
    Private Sub QuickSort(ByVal C() As Integer, ByVal First As Long, ByVal Last As Long)
        '
        '  Made by Michael Ciurescu (CVMichael from vbforums.com)
        '  Original thread: [url]http://www.vbforums.com/showthread.php?t=231925[/url]
        '
        Dim Low As Long, High As Long
        Dim MidValue As String

        Low = First
        High = Last
        MidValue = C((First + Last) \ 2)

        Do
            While C(Low) < MidValue
                Low = Low + 1
            End While

            While C(High) > MidValue
                High = High - 1
            End While

            If Low <= High Then
                Swap(C(Low), C(High))
                Low = Low + 1
                High = High - 1
            End If
        Loop While Low <= High

        If First < High Then QuickSort(C, First, High)
        If Low < Last Then QuickSort(C, Low, Last)
    End Sub

    Private Sub Swap(ByRef A As String, ByRef B As String)
        Dim T As String

        T = A
        A = B
        B = T
    End Sub
    'Swap es parte de quicksort



    Public Function HeapSort(ByRef Keys() As Integer)
        Dim Base As Long : Base = LBound(Keys)                    ' array index base
        Dim n As Long : n = UBound(Keys) - LBound(Keys) + 1       ' array size
        ' ReDim Index(Base To Base + n - 1) As Long                ' allocate index array
        Dim i As Long, m As Long
        Base = 0
        m = arr.Length - 1
        For i = 0 To n - 1 : Index(Base + i) = Base + i : Next     ' fill index array
        For i = n \ 2 - 1 To 0 Step -1                           ' generate ordered heap
            Heapify(Keys, Index, i, n)
        Next
        For m = n To 2 Step -1
            Exchange(Index, 0, m - 1)                              ' move highest element to top
            Heapify(Keys, Index, 0, m - 1)
        Next
        HeapSort = Index
    End Function

    Private Sub Heapify(ByRef Keys() As Integer, Index() As Integer, ByVal i1 As Long, ByVal n As Long)
        ' Heap order rule: a[i] >= a[2*i+1] and a[i] >= a[2*i+2]
        Dim Base As Long : Base = LBound(Index)
        Dim nDiv2 As Long : nDiv2 = n \ 2
        Dim i As Long : i = i1
        Do While i < nDiv2
            Dim k As Long : k = 2 * i + 1
            If k + 1 < n Then
                If Keys(Index(Base + k)) < Keys(Index(Base + k + 1)) Then k = k + 1
            End If
            If Keys(Index(Base + i)) >= Keys(Index(Base + k)) Then Exit Do
            Exchange(Index, i, k)
            i = k
        Loop
    End Sub

    Private Sub Exchange(a() As Integer, ByVal i As Long, ByVal j As Long)
        Dim Base As Long : Base = LBound(a)
        Dim Temp As Long : Temp = a(Base + i)
        a(Base + i) = a(Base + j)
        a(Base + j) = Temp
    End Sub
    ''''''''''''''''''''''''''''''''''''''''''''''
    'Otra version de quicksort
    Public Sub QuickSort2(ByRef lngArray() As Integer)
        Dim iLBound As Long
        Dim iUBound As Long
        Dim iTemp As Long
        Dim iOuter As Long
        Dim iMax As Long

        iLBound = LBound(lngArray)
        iUBound = UBound(lngArray)

        'Dont want to sort array with only 1 value
        If (iUBound - iLBound) Then

            'Move the largest value to the rightmost position, otherwise
            'we need to check that iLeftCur does not exceed the bounds of the
            'array on EVERY pass (time consuming)

            For iOuter = iLBound To iUBound
                If lngArray(iOuter) > lngArray(iMax) Then iMax = iOuter
            Next iOuter

            iTemp = lngArray(iMax)
            lngArray(iMax) = lngArray(iUBound)
            lngArray(iUBound) = iTemp

            'Start quicksorting
            InnerQuickSort(lngArray, iLBound, iUBound)
        End If
    End Sub

    Private Sub InnerQuickSort(ByRef lngArray() As Integer, ByVal iLeftEnd As Long, ByVal iRightEnd As Long)
        Dim iLeftCur As Long
        Dim iRightCur As Long
        Dim iPivot As Long
        Dim iTemp As Long

        If iLeftEnd >= iRightEnd Then Exit Sub

        iLeftCur = iLeftEnd
        iRightCur = iRightEnd + 1
        iPivot = lngArray(iLeftEnd)

        'Arrange values so that < pivot are on the left and > pivot are on the right
        Do
            'Find >= value on left side
            Do
                iLeftCur = iLeftCur + 1
            Loop While lngArray(iLeftCur) < iPivot

            'Find <= value on right side
            Do
                iRightCur = iRightCur - 1
            Loop While lngArray(iRightCur) > iPivot

            'No more swapping to do
            If iLeftCur >= iRightCur Then Exit Do

            'Swap
            iTemp = lngArray(iLeftCur)
            lngArray(iLeftCur) = lngArray(iRightCur)
            lngArray(iRightCur) = iTemp
        Loop

        'Call quicksort recursively on left and right subarrays
        lngArray(iLeftEnd) = lngArray(iRightCur)
        lngArray(iRightCur) = iPivot

        InnerQuickSort(lngArray, iLeftEnd, iRightCur - 1)
        InnerQuickSort(lngArray, iRightCur + 1, iRightEnd)
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub RadixSort(ByRef lngArray() As Integer)
        'tomado de http://www.xtremevbtalk.com/showthread.php?p=386994
        Dim iLBound As Long
        Dim iUBound As Long
        Dim iMax As Long
        Dim iSorts As Long
        Dim iLoop As Long

        iLBound = LBound(lngArray)
        iUBound = UBound(lngArray)

        'Create swap array


        iMax = &H80000000
        'Find largest
        For iLoop = iLBound To iUBound
            If lngArray(iLoop) > iMax Then iMax = lngArray(iLoop)
        Next iLoop

        'Calculate how many sorts are needed
        Do While iMax
            iSorts = iSorts + 1
            iMax = iMax \ 256
        Loop

        iMax = 1

        'Do the sorts
        For iLoop = 1 To iSorts

            If iLoop And 1 Then
                'Odd sort -> src to dest
                InnerRadixSort(lngArray, arrTemp, iLBound, iUBound, iMax)
            Else
                'Even sort -> dest to src
                InnerRadixSort(arrTemp, lngArray, iLBound, iUBound, iMax)
            End If

            'Next sort factor
            iMax = iMax * 256
        Next iLoop

        'If odd number of sorts we need to swap the arrays
        If (iSorts And 1) Then
            For iLoop = iLBound To iUBound
                lngArray(iLoop) = arrTemp(iLoop)
            Next iLoop
        End If
    End Sub

    Private Sub InnerRadixSort(ByRef lngSrc() As Integer, ByRef lngDest() As Integer, ByVal iLBound As Long, ByVal iUBound As Long, ByVal iDivisor As Long)
        Dim arrCounts(255) As Long
        Dim arrOffsets(255) As Long
        Dim iBucket As Long
        Dim iLoop As Long

        'Count the items for each bucket
        For iLoop = iLBound To iUBound
            iBucket = (lngSrc(iLoop) \ iDivisor) And 255
            arrCounts(iBucket) = arrCounts(iBucket) + 1
        Next iLoop

        'Generate offsets
        For iLoop = 1 To 255
            arrOffsets(iLoop) = arrOffsets(iLoop - 1) + arrCounts(iLoop - 1) + iLBound
        Next iLoop

        'Fill the buckets
        For iLoop = iLBound To iUBound
            iBucket = (lngSrc(iLoop) \ iDivisor) And 255
            lngDest(arrOffsets(iBucket)) = lngSrc(iLoop)
            arrOffsets(iBucket) = arrOffsets(iBucket) + 1
        Next iLoop
    End Sub
 
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        btnLlenar_Click(sender, e)
    End Sub
End Class
