class MyButton
{
    public string Text;

    // 이벤트 정의
    public event EventHandler Click;

    public void MouseButtonDown()
    {
        if (this.Click != null)
        {
            // 이벤트핸들러들을 호출
            Click(this, EventArgs.Empty);
        }
    }
}