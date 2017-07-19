package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�́E���i�R�t�\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceMediaProductDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�́E���i�R�t�o�^�f�[�^VO */
    private RegistMbj27MediaProductVO _mediaProductVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceMediaProductDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceMediaProductDispVO();
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