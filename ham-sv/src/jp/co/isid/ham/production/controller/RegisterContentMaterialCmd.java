package jp.co.isid.ham.production.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.ham.production.model.RegisterMaterialVO;
import jp.co.isid.ham.production.model.MaterialRegisterManager;
import jp.co.isid.ham.production.model.MaterialRegisterResult;

/**
 * <P>
 * CR�����@�o�^���s���̃R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class RegisterContentMaterialCmd extends Command {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    private RegisterMaterialVO _vo = null;

    @Override
    public void execute() throws UserException {
        MaterialRegisterResult result = new MaterialRegisterResult();
        result = MaterialRegisterManager.getInstance().executeContentMaterialInfo(_vo);

        super.getResult().set(RESULT_KEY, result);
    }

    /**
     * �f�ޓo�^�pVO��ݒ肵�܂�
     * @param vo
     */
    public void setRegisterContentMaterialVO(RegisterMaterialVO vo) {
        _vo = vo;
    }

    /**
     * �f�ޓo�^���ʃN���X���擾���܂�
     * @return
     */
    public MaterialRegisterResult getMaterialRegisterResult() {
        return (MaterialRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
