package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindAccountBookOutPutDataCondition;
import jp.co.isid.ham.media.model.FindAccountBookOutPutDataResult;
import jp.co.isid.ham.media.model.FindAccountBookOutputManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �c�ƍ�Ƒ䒠���[�o�̓f�[�^�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/26 HLC M.Tsuchiya)<BR>
 * </P>
 * @author HLC M.Tsuchiya
 */
public class FindAccountBookOutPutDataCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

   /** �������ʃL�[ */
   private static final String RESULT_KEY = "RESULT_KEY";

   /** �������� */
   private FindAccountBookOutPutDataCondition _condition;


   /**
    * �����������g�p���A �c�ƍ�Ƒ䒠���[�o�̓f�[�^�������������s���܂�
    * @throws HAMException
    *             �����Ɏ��s�����ꍇ
    */
   @Override
    public void execute() throws UserException {
       FindAccountBookOutputManager manager = FindAccountBookOutputManager.getInstance();
        FindAccountBookOutPutDataResult result = manager.findAuthorityAccountBookReport(_condition);
        getResult().set(RESULT_KEY, result);
    }

   /**
    * ����������ݒ肵�܂�
    * @param condition ��������
    */
   public void setAccountBookOutPutDataCondition(FindAccountBookOutPutDataCondition condition) {
       _condition = condition;
   }

   /**
    * �������ʂ�Ԃ��܂�
    * @return FindAuthorityAccountBookResult ������������
    */
   public FindAccountBookOutPutDataResult getFindAccountBookOutPutDataResult() {
       return (FindAccountBookOutPutDataResult) super.getResult().get(RESULT_KEY);
   }
}
