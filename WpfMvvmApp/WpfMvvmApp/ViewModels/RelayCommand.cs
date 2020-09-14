using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmApp.ViewModels
{
    public class RelayCommand<T> : ICommand
    {
        private Action<T> execute;
        readonly Predicate<T> canExecute;
        public event EventHandler CanExecuteChanged 
        {
            add => CommandManager.RequerySuggested += value; //추가된이벤트가있으면 추가
            remove => CommandManager.RequerySuggested -= value; //빼기
            //delegate chain?
        }

        //생성자
        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute)); //?
            this.canExecute = canExecute;
        }

        //action canexecute만 받음
        public RelayCommand(Action<T> execute) : this(execute,null) //this(execute)에서 
        {
        }

        public bool CanExecute(object parameter) => canExecute?.Invoke((T)parameter) ?? true; //canExecute가 null이아니면 파라미터넘겨줌
                                                                                              //true,false넘겨주는데 null아니면 true
                                                                                              //뭔가 있으면 넘겨주기

        public void Execute(object parameter) => execute((T)parameter);

        //execute : 버튼 눌렀을때 데이터 넣는것
        //CanExecute : 넘겨줄 데이터 있는지 확인하는것
    }
}
