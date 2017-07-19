package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̕\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceMediaDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�̓o�^�f�[�^VO */
    private RegistMbj03MediaVO _mediaVO = null;

    /** �}�̌����o�^�f�[�^VO */
    private RegistMbj10MediaSecVO _mediaAuthorityVO = null;

    /** �}�̏o�͐ݒ�o�^�f�[�^VO */
    private RegistMbj14MediaOutCtrlVO _mediaOutControlVO = null;

    /** ��p���No�o�^�f�[�^VO */
    private RegistMbj09HiyouVO _costPlanVO = null;

    /** �}�́E���i�R�t�o�^�f�[�^VO */
    private RegistMbj27MediaProductVO _mediaProductVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceMediaDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceMediaDispVO();
    }

    /**
     * �}�̓o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _mediaVO
     */
    public void setMediaVO(RegistMbj03MediaVO vo)
    {
        _mediaVO = vo;
    }

    /**
     * �}�̓o�^�f�[�^VO���擾���܂�
     * @return _mediaVO
     */
    public RegistMbj03MediaVO getMediaVO()
    {
        return _mediaVO;
    }

    /**
     * �}�̌����o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _mediaAuthorityVO
     */
    public void setMediaAuthorityVO(RegistMbj10MediaSecVO vo)
    {
        _mediaAuthorityVO = vo;
    }

    /**
     * �}�̌����o�^�f�[�^VO���擾���܂�
     * @return _mediaAuthorityVO
     */
    public RegistMbj10MediaSecVO getMediaAuthorityVO()
    {
        return _mediaAuthorityVO;
    }

    /**
     * �}�̏o�͐ݒ�o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _mediaOutControlVO
     */
    public void setMediaOutControlVO(RegistMbj14MediaOutCtrlVO vo)
    {
        _mediaOutControlVO = vo;
    }

    /**
     * �}�̏o�͐ݒ�o�^�f�[�^VO���擾���܂�
     * @return _mediaOutControlVO
     */
    public RegistMbj14MediaOutCtrlVO getMediaOutControlVO()
    {
        return _mediaOutControlVO;
    }

    /**
     * ��p���No�o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _costPlanVO
     */
    public void setCostPlanVO(RegistMbj09HiyouVO vo)
    {
        _costPlanVO = vo;
    }

    /**
     * ��p���No�o�^�f�[�^VO���擾���܂�
     * @return _costPlanVO
     */
    public RegistMbj09HiyouVO getCostPlanVO()
    {
        return _costPlanVO;
    }

    /**
     * �}�́E���i�R�t�o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _mediaProductVO
     */
    public void setMediaProductVO(RegistMbj27MediaProductVO vo)
    {
        _mediaProductVO = vo;
    }

    /**
     * �}�́E���i�R�t�o�^�f�[�^VO���擾���܂�
     * @return _mediaProductVO
     */
    public RegistMbj27MediaProductVO getMediaProductVO()
    {
        return _mediaProductVO;
    }

}
