package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM�S���ҕ\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceHMUserDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HM�S���ғo�^�f�[�^VO */
    private RegistMbj48HmUserVO _hmUserVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceHMUserDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RegistMasterMaintenanceHMUserDispVO();
    }

    /**
     * HM�S���ғo�^�f�[�^VO��ݒ肵�܂�
     * @param vo RegistMbj48HmUserVO HM�S���ғo�^�f�[�^VO
     */
    public void setHMUserVO(RegistMbj48HmUserVO vo) {
        _hmUserVO = vo;
    }

    /**
     * HM�S���ғo�^�f�[�^VO���擾���܂�
     * @return RegistMbj48HmUserVO HM�S���ғo�^�f�[�^VO
     */
    public RegistMbj48HmUserVO getHMUserVO() {
        return _hmUserVO;
    }

}
