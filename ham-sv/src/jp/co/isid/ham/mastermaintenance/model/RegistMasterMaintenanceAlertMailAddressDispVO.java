package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���[���z�M�\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/07 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceAlertMailAddressDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���[���z�M�o�^�f�[�^VO */
    private RegistMbj40AlertMailAddressVO _alertMailAddressVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceAlertMailAddressDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceAlertMailAddressDispVO();
    }

    /**
     * ���[���z�M�o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _alartMailAddressVO
     */
    public void setAlertMailAddressVO(RegistMbj40AlertMailAddressVO vo)
    {
        _alertMailAddressVO = vo;
    }

    /**
     * ���[���z�M�o�^�f�[�^VO���擾���܂�
     * @return _alartMailAddressVO
     */
    public RegistMbj40AlertMailAddressVO getAlertMailAddressVO()
    {
        return _alertMailAddressVO;
    }

}
