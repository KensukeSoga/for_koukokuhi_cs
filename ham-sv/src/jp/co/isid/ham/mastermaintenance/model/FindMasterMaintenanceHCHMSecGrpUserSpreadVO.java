package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �Z�L�����e�B�O���[�v���[�U�[(HC/HM)�����f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCHMSecGrpUserSpreadVO {

    private static final long serialVersionUID = 1L;

    /** �f�[�^VO���X�g */
    private List<MasterMaintenanceHCHMSecGrpUserSpreadVO> _findList;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindMasterMaintenanceHCHMSecGrpUserSpreadVO()
    {
    }

    /**
     * �f�[�^VO���X�g��ݒ肵�܂�
     * @param voList �Z�b�g���� _findList
     */
    public void setFindList(List<MasterMaintenanceHCHMSecGrpUserSpreadVO> voList)
    {
        _findList = voList;
    }

    /**
     * �f�[�^VO���X�g���擾���܂�
     * @return _findList
     */
    public List<MasterMaintenanceHCHMSecGrpUserSpreadVO> getFindList()
    {
        return _findList;
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
