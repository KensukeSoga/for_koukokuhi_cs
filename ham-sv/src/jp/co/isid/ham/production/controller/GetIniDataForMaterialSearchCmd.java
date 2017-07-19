package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.ContractRegisterManager;
import jp.co.isid.ham.production.model.MaterialSearchCondition;
import jp.co.isid.ham.production.model.MaterialSearchResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 *
 * @author HAM�`�[��
 *
 */
public class GetIniDataForMaterialSearchCmd extends Command  {

    /**
	 *
	 */
	private static final long serialVersionUID = 1L;

	/** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private MaterialSearchCondition _condition;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
	public void execute() throws UserException {
		ContractRegisterManager manager = ContractRegisterManager.getInstance();
		MaterialSearchResult result = manager.getIniDataForMaterialSearch(_condition);
        getResult().set(RESULT_KEY, result);
	}

	/**
	 * ����������ݒ肵�܂�
	 * @param condition ContractRegisterCondition ��������
	 */
	public void setMaterialSearchCondition(MaterialSearchCondition condition) {
		_condition = condition;
	}

	/**
	 * ���ʂ��擾���܂�
	 * @return ContractRegisterResult ����
	 */
	public MaterialSearchResult getMaterialSearchResult() {
		return (MaterialSearchResult)super.getResult().get(RESULT_KEY);
	}

}
