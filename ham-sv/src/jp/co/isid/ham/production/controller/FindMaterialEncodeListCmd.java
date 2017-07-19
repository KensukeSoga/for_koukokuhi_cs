package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.MaterialRegisterManager;
import jp.co.isid.ham.production.model.MaterialRegisterResult;
import jp.co.isid.ham.production.model.MaterialEncodeListCondition;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 *
 * @author HAM�`�[��
 *
 */
public class FindMaterialEncodeListCmd extends Command  {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private MaterialEncodeListCondition _condition;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    public void execute() throws UserException {
        MaterialRegisterManager manager = MaterialRegisterManager.getInstance();
        MaterialRegisterResult result = manager.findMaterialEncodeList(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     * @param condition MaterialEncodeCondition ��������
     */
    public void setMaterialEncodeCondition(MaterialEncodeListCondition condition) {
        _condition = condition;
    }

    /**
     * ���ʂ��擾���܂�
     * @return MaterialRegisterResult ����
     */
    public MaterialRegisterResult getMaterialRegisterResult() {
        return (MaterialRegisterResult)super.getResult().get(RESULT_KEY);
    }

}
