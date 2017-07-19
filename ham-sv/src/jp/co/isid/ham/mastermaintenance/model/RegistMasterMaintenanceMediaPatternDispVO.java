package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̃p�^�[���\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceMediaPatternDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�̃p�^�[���o�^�f�[�^VO */
    private RegistMbj35MediaPatternVO _mediaPatternVO = null;

    /** �}�̃p�^�[�����e�o�^�f�[�^VO */
    private RegistMbj36MediaPatternItemVO _mediaPatternItemVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceMediaPatternDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceMediaPatternDispVO();
    }

    /**
     * �}�̃p�^�[���o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _mediaPatternVO
     */
    public void setMediaPatternVO(RegistMbj35MediaPatternVO vo)
    {
        _mediaPatternVO = vo;
    }

    /**
     * �}�̃p�^�[���o�^�f�[�^VO���擾���܂�
     * @return _mediaPatternVO
     */
    public RegistMbj35MediaPatternVO getMediaPatternVO()
    {
        return _mediaPatternVO;
    }

    /**
     * �}�̃p�^�[�����e�o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _mediaPatternItemVO
     */
    public void setMediaPatternItemVO(RegistMbj36MediaPatternItemVO vo)
    {
        _mediaPatternItemVO = vo;
    }

    /**
     * �}�̃p�^�[�����e�o�^�f�[�^VO���擾���܂�
     * @return _mediaPatternItemVO
     */
    public RegistMbj36MediaPatternItemVO getMediaPatternItemVO()
    {
        return _mediaPatternItemVO;
    }

}
