package jp.co.isid.ham.login.model;

import jp.co.isid.ham.integ.tbl.Mfk02Jun;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���J�͈́^���j�b�gNo.�}�X�^���VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/06/04 JSE K.Tamura)<BR>
 * </P>
 * @author JSE K.Tamura
 */
public class KhUnMstVO extends AbstractModel {

	private static final long serialVersionUID = -854815678173627464L;

	/**
     * �V�K�C���X�^���X���\�z���܂�
     */
    public KhUnMstVO() {
    }

    /**
     * �V�K�C���X�^���X���\�z���܂�
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new KhUnMstVO();
    }

    /**
     * ���Ӑ�R�[�h�i10���j���擾����
     * @return ���Ӑ�R�[�h�i10���j
     */
    public String getZsbch0317() {
        return (String) get(Mfk02Jun.ZSBCH0317);
    }

    /**
     * ���Ӑ�R�[�h�i10���j��ݒ肷��
     * @param val ZSBCH0317 ���Ӑ�R�[�h�i10���j
     */
    public void setZsbch0317(String val) {
        set(Mfk02Jun.ZSBCH0317, val);
    }

}