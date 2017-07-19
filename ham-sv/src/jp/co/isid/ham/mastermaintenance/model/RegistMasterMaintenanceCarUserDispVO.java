package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �Ԏ�S���\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceCarUserDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �Ԏ�S���o�^�f�[�^VO */
    private RegistMbj23CarTantoVO _carUserVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceCarUserDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceCarUserDispVO();
    }

    /**
     * �Ԏ�S���o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carUserVO
     */
    public void setCarUserVO(RegistMbj23CarTantoVO vo)
    {
        _carUserVO = vo;
    }

    /**
     * �Ԏ�S���o�^�f�[�^VO���擾���܂�
     * @return _carUserVO
     */
    public RegistMbj23CarTantoVO getCarUserVO()
    {
        return _carUserVO;
    }

}
