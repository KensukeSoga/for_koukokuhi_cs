package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.production.model.ContractDeleteCondition;
import jp.co.isid.ham.production.model.ContractDeleteResult;
import jp.co.isid.ham.production.model.ContractRegisterManager;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �_����o�^��ʋN�����f�[�^�擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/14 JSE A.Naito)<BR>
 * </P>
 * @author
 */
public class ContractDeleteCmd extends Command {

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private ContractDeleteCondition _condition;

    /**
    *
    */
   private static final long serialVersionUID = 1L;

   /**
    * �����������g�p���A�������������s���܂�
    * @throws HAMException �����Ɏ��s�����ꍇ
    */
   public void execute() throws UserException {
       ContractDeleteResult result = new ContractDeleteResult();
       ContractRegisterManager manager = ContractRegisterManager.getInstance();
       result = manager.countByCondition(_condition);
       getResult().set(RESULT_KEY, result);
   }

   /**
    * ����������ݒ肵�܂�
    *
    * @param condition CommonCodeMasterSearchCondition ��������
    */
   public void setContractDeleteCondition(ContractDeleteCondition condition) {
       _condition = condition;
   }

   /**
    * �����������ʂ�Ԃ��܂�
    *
    * @return ContractRegisterResult ������������
    */
   public ContractDeleteResult getContractDeleteResult() {
       return (ContractDeleteResult) super.getResult().get(RESULT_KEY);
   }
}
