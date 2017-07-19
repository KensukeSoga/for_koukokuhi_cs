package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.production.model.ContractRegisterManager;
import jp.co.isid.ham.production.model.UpdateContractInfoResult;
import jp.co.isid.ham.production.model.UpdateContractInfoVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �_����o�^���Update�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/18 JSE A.Naito)<BR>
 * </P>
 * @author
 */
public class UpdateContractInfoCmd extends Command {

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private UpdateContractInfoVO _condition;

    /**
    *
    */
   private static final long serialVersionUID = 1L;

   /**
    * �����������g�p���A�������������s���܂�
    * @throws HAMException �����Ɏ��s�����ꍇ
    */
   public void execute() throws UserException {
       UpdateContractInfoResult result = new UpdateContractInfoResult();
       ContractRegisterManager manager = ContractRegisterManager.getInstance();
       result = manager.updateByCondition(_condition);
       getResult().set(RESULT_KEY, result);
   }

   /**
    * ����������ݒ肵�܂�
    *
    * @param condition CommonCodeMasterSearchCondition ��������
    */
   public void setUpdateContractInfoCondition(UpdateContractInfoVO condition) {
       _condition = condition;
   }

   /**
    * �����������ʂ�Ԃ��܂�
    *
    * @return UpdateContractInfoResult ������������
    */
   public UpdateContractInfoResult getUpdateContractInfoResult() {
       return (UpdateContractInfoResult) super.getResult().get(RESULT_KEY);
   }
}
