package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.ContractSearchManager;
import jp.co.isid.ham.production.model.ContractSearchResult;
import jp.co.isid.ham.production.model.ContractSearchCondition;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 *
 * @author HAM�`�[��
 *
 */
public class FindContractSearchCmd extends Command  {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private ContractSearchCondition _condition;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    public void execute() throws UserException {
        ContractSearchManager manager = ContractSearchManager.getInstance();
        ContractSearchResult result = manager.getContractListByCondition(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     * @param condition ContractSearchCondition ��������
     */
    public void setContractSearchCondition(ContractSearchCondition condition) {
        _condition = condition;
    }

    /**
     * ���ʂ��擾���܂�
     * @return ContractSearchResult ����
     */
    public ContractSearchResult getContractSearchResult() {
        return (ContractSearchResult)super.getResult().get(RESULT_KEY);
    }

}
