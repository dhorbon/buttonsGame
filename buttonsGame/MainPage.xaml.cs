using System.Diagnostics;

namespace buttonsGame
{

    public partial class MainPage : ContentPage
    {
        public int size;
        public int score = 1;
        List<List<BButton>> buttons = new();

        public MainPage()
        {
            InitializeComponent();
        }

        public void Play(object sender, EventArgs e)
        {
            size = Convert.ToInt16(SizeInput.Text);
            if (Convert.ToInt16(size)<3 || (Convert.ToInt16(size) % 2) != 1)
            {
                errormessage.IsVisible = true; return;
            }
            
            for(int i = 0; i < size; i++)
            {
                game.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
                game.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
            }

            for(int i = 0;i < size; i++)
            {
                buttons.Add(new());
                for(int j = 0; j < size; j++)
                {
                    buttons[i].Add(new(i,j));
                    buttons[i][j].Clicked += (sender, e) =>
                    {
                        BButton bt = (BButton)sender;
                        int x = bt.x;
                        int y = bt.y;

                        try
                        {
                            buttons[x][y].ClickFun();
                            if (buttons[x][y].state)
                            {
                                score++;
                            }
                            else
                            {
                                score--;
                            }
                        }
                        catch { }
                        try
                        {
                            buttons[x + 1][y].ClickFun();
                            if (buttons[x + 1][y].state)
                            {
                                score++;
                            }
                            else
                            {
                                score--;
                            }
                        }
                        catch { }
                        try
                        {
                            buttons[x - 1][y].ClickFun();
                            if (buttons[x - 1][y].state)
                            {
                                score++;
                            }
                            else
                            {
                                score--;
                            }
                        }
                        catch { }
                        try
                        {
                            buttons[x][y + 1].ClickFun();
                            if (buttons[x][y + 1].state)
                            {
                                score++;
                            }
                            else
                            {
                                score--;
                            }
                        }
                        catch { }
                        try
                        {
                            buttons[x][y - 1].ClickFun();
                            if (buttons[x][y - 1].state)
                            {
                                score++;
                            }
                            else
                            {
                                score--;
                            }
                        }
                        catch { }

                        if(score == size * size)
                        {
                            DisplayAlert("Wygrales!","Wygrales gre!","zamknij");
                        }
                    };
                    game.Add(buttons[i][j],i,j);
                }
            }

            buttons[(size - 1) / 2][(size - 1) / 2].ClickFun();

            start.IsVisible = false;
        }
    }

}
