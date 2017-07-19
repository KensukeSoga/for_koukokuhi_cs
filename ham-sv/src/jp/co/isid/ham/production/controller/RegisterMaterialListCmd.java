package jp.co.isid.ham.production.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.ham.production.model.RegisterMaterialListVO;
import jp.co.isid.ham.production.model.MaterialListManager;
import jp.co.isid.ham.production.model.MaterialListResult;

/**
 * <P>
 * �f�ވꗗ�@�o�^���s���̃R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class RegisterMaterialListCmd extends Command {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    private RegisterMaterialListVO _vo = null;

    @Override
    public void execute() throws UserException {
        MaterialListResult result = new MaterialListResult();
        result = MaterialListManager.getInstance().executeMaterialListInfo(_vo);

        super.getResult().set(RESULT_KEY, result);
    }

    /**
     * �f�ޓo�^�pVO��ݒ肵�܂�
     * @param vo
     */
    public void setRegisterMaterialListVO(RegisterMaterialListVO vo) {
        _vo = vo;
    }

    /**
     * �f�ޓo�^���ʃN���X���擾���܂�
     * @return
     */
    public MaterialListResult getMaterialListResult() {
        return (MaterialListResult) super.getResult().get(RESULT_KEY);
    }

}
