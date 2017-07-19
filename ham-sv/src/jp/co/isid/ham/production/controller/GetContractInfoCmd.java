package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.ContractRegisterManager;
import jp.co.isid.ham.production.model.GetContractInfoListCondition;
import jp.co.isid.ham.production.model.GetContractInfoListResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �_����o�^�N�����f�[�^�擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/03 JSE A.Naito)<BR>
 * </P>
 * @author
 */
public class GetContractInfoCmd extends Command {

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private GetContractInfoListCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 8L;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    public void execute() throws UserException {
        GetContractInfoListResult result = new GetContractInfoListResult();
        ContractRegisterManager manager = ContractRegisterManager.getInstance();
        result = manager.getContractByCondition(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition CommonCodeMasterSearchCondition ��������
     */
    public void setContractInfoCondition(GetContractInfoListCondition condition) {
        _condition = condition;
    }

    /**
     * �����������ʂ�Ԃ��܂�
     *
     * @return ContractRegisterResult ������������
     */
    public GetContractInfoListResult getContractInfoListResult() {
        return (GetContractInfoListResult) super.getResult().get(RESULT_KEY);
    }

}
