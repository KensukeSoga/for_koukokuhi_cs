package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj52SzTntUserVO;
import jp.co.isid.ham.common.model.RegistExclusionVO;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �Ԏ�S����(�f��)�o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/02/23 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMbj52SzTntUserVO extends AbstractModel
{
    private static final long serialVersionUID = 1L;

    /** �r�����b�N���VO */
    RegistExclusionVO _exclusion;

    /** �f�[�^VO�}�����X�g */
    private List<Mbj52SzTntUserVO> _insertList;

    /** �f�[�^VO�폜���X�g */
    private List<Mbj52SzTntUserVO> _deleteList;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMbj52SzTntUserVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMbj52SzTntUserVO();
    }

    /**
     * �r�����b�N���VO���擾���܂�
     * @return _exclusion
     */
    public RegistExclusionVO getExclusion()
    {
        return _exclusion;
    }

    /**
     * �f�[�^VO�}�����X�g��ݒ肵�܂�
     * @param voList �Z�b�g���� _insertList
     */
    public void setInsertList(List<Mbj52SzTntUserVO> voList)
    {
        _insertList = voList;
    }

    /**
     * �f�[�^VO�}�����X�g���擾���܂�
     * @return _insertList
     */
    public List<Mbj52SzTntUserVO> getInsertList()
    {
        return _insertList;
    }

    /**
     * �f�[�^VO�폜���X�g��ݒ肵�܂�
     * @param voList �Z�b�g���� _deleteList
     */
    public void setDeleteList(List<Mbj52SzTntUserVO> voList)
    {
        _deleteList = voList;
    }

    /**
     * �f�[�^VO�폜���X�g���擾���܂�
     * @return _deleteList
     */
    public List<Mbj52SzTntUserVO> getDeleteList()
    {
        return _deleteList;
    }

    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy)
    {
        _dummy = dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy()
    {
        return _dummy;
    }
}
